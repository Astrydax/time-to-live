using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : ClickableObject
{
    public bool isUp = true;
    public int shiftAmount = 10;
    public override void OnClick(GameObject clicker)
    {
        if (clicker.GetComponent<ClickStates>().isAlive)
        {
            if (isUp)
            {
                Camera.main.GetComponent<CameraController>().GoUp(shiftAmount);
            }
            else
            {
                Camera.main.GetComponent<CameraController>().GoDown(shiftAmount);
            }
        }

    }

    public override void OnRelease(GameObject clicker)
    {
        //when the object is released
    }
}
