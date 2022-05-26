using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : MonoBehaviour
{
    public GameObject unpressed, pressed;

    public bool testFlag;

    public int clickers = 0;
    private void Start()
    {
        unpressed.SetActive(true);
        pressed.SetActive(false);

    }

    public void OnClick(GameObject clicker)
    {
        clickers++;
        Debug.Log("You Clicked the button!");
        pressed.SetActive(true);
        unpressed.SetActive(false);

        //this is only used for testing, remove before deploy
        if (clicker.GetComponent<ClickStates>().isAlive && testFlag)
        {
            GameEventsManager.instance.PlayerRespawned();
        }
        

    }

    public void OnRelease(GameObject clicker)
    {
        clickers--;
        //ONLY CALL THIS IF NO CURSORS ARE CLICKING
        if(clickers <= 0)
        {
            Debug.Log("I've been released");
            pressed.SetActive(false);
            unpressed.SetActive(true);
        }   
        
        
    }
}
