using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : ClickableObject
{
    public bool isUp = true;
    public override void OnClick(GameObject clicker)
    {
        if (clicker.GetComponent<ClickStates>().isAlive)
        {
            if (isUp)
            {
                Camera.main.GetComponent<CameraController>().GoUp();
            }
            else
            {
                Camera.main.GetComponent<CameraController>().GoDown();
            }
        }

    }

    public override void OnRelease(GameObject clicker)
    {
        //when the object is released
    }
}
