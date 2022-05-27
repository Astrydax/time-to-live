using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : ClickableObject
{
    public GameObject unpressed, pressed;

    public bool testFlag;

    public int clickers = 0;
    private void Start()
    {
        unpressed.SetActive(true);
        pressed.SetActive(false);

    }

    public override void OnClick(GameObject clicker)
    {
        clickers++;
        pressed.SetActive(true);
        unpressed.SetActive(false);       

    }

    public override void OnRelease(GameObject clicker)
    {
        clickers--;
        //ONLY CALL THIS IF NO CURSORS ARE CLICKING
        if(clickers <= 0)
        {
            pressed.SetActive(false);
            unpressed.SetActive(true);
        }   
        
        
    }
}
