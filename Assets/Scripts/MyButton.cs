using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : ClickableObject
{
    public GameObject unpressed, pressed;

    public bool isPressed = false;

    public int clickers = 0;
    private void Start()
    {
        unpressed.SetActive(true);
        pressed.SetActive(false);
        GameEventsManager.instance.onPlayerRespawn += OnPlayerRespawn;
    }

    private void OnDestroy()
    {
        // unsubscribe from events
        GameEventsManager.instance.onPlayerRespawn -= OnPlayerRespawn;
    }

    private void OnPlayerRespawn()
    {
        clickers = 0;        
    }

    public override void OnClick(GameObject clicker)
    {
        clickers++;       

    }

    public override void OnRelease(GameObject clicker)
    {
        clickers--;
    }

    private void Update()
    {
        if(clickers > 0)
        {
            isPressed = true;
            pressed.SetActive(true);
            unpressed.SetActive(false);
        }
        else
        {
            isPressed = false;
            pressed.SetActive(false);
            unpressed.SetActive(true);
        }
    }
}
