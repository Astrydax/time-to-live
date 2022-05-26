using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public bool isUp = true;
    public void OnClick(GameObject clicker)
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

    public void OnRelease(GameObject clicker)
    {
        //when the object is released
    }
}
