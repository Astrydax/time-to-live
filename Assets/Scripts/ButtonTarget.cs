using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTarget : MonoBehaviour
{
    public GameObject[] objectsToReveal;
    public MyButton[] requiredButtons;

    // Start is called before the first frame update
    void Start()
    {
        GameEventsManager.instance.onPlayerRespawn += OnPlayerRespawn;
        DisableAllObjects();
    }

    private void OnDestroy()
    {
        // unsubscribe from events
        GameEventsManager.instance.onPlayerRespawn -= OnPlayerRespawn;
    }

    private void OnPlayerRespawn()
    {
        DisableAllObjects();
    }


    public void Update()
    {
        bool allButtonsPressed = true;
        foreach(MyButton button in requiredButtons)
        {
            if(!button.isPressed)
            {
                allButtonsPressed = false;
            }
        }

        if (allButtonsPressed)
        {
            EnableAllObjects();
        }
        else
        {
            DisableAllObjects();
        }
    }

    private void DisableAllObjects()
    {
        foreach (GameObject obj in objectsToReveal)
        {
            obj.SetActive(false);
        }
    }

    private void EnableAllObjects()
    {
        foreach (GameObject obj in objectsToReveal)
        {
            //bleh button re-enables collected points on update
            if(obj.GetComponent<PointController>() && obj.GetComponent<PointController>().collectedThisLoop)
            {
                obj.SetActive(false);
            }
            else
            {
                obj.SetActive(true);
            }
            
        }
    }
}
