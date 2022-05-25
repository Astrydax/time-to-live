using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void GoUp()
    {
        this.transform.position = new Vector3(0, transform.position.y + 10, transform.position.z);
    }

    public void GoDown()
    {
        this.transform.position = new Vector3(0, transform.position.y - 10, transform.position.z);
    }
}
