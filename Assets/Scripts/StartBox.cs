using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBox : Box
{
    public override void OnClick(GameObject clicker)
    {
        base.OnClick(clicker);
        if (clicker.GetComponent<ClickStates>().isAlive)
        {
            if (!GameManager.instance.gamePlaying)
            {
                GameEventsManager.instance.GameStart();
            }
            
        }
        
    }
}
