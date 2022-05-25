using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.transform.position = new Vector3(0, -10, -10);
    }

    public void OnGameStart()
    {
        mainCamera.transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //git test
    //testing branch behind master
}
