using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void GoUp(int amt)
    {
        this.transform.position = new Vector3(0, transform.position.y + amt, transform.position.z);
    }

    public void GoDown(int amt)
    {
        this.transform.position = new Vector3(0, transform.position.y - amt, transform.position.z);
    }
}
