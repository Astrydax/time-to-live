using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStates : MonoBehaviour
{
    public bool startedClick, holdingClick, endedClick;

    public bool isAlive = false;

    public ClickableObject lastClicked;

    public GameObject clickFX;


    void Start()
    {
        GameEventsManager.instance.onPlayerRespawn += OnPlayerRespawn;
    }

    private void OnDestroy()
    {
        // unsubscribe from events
        GameEventsManager.instance.onPlayerRespawn -= OnPlayerRespawn;
    }

    private void OnPlayerRespawn()
    {
        lastClicked = null;
    }

    private void Update()
    {
        if (startedClick)
        {
            GameObject fx = Instantiate(clickFX, this.transform);
            fx.transform.parent = null;
        }
        
        if (startedClick && lastClicked == null)
        {
            RaycastHit2D hit = FireRay();
            if (hit.collider != null)
            {
                lastClicked = hit.collider.gameObject.GetComponent<ClickableObject>();
                if(lastClicked != null)
                {
                    lastClicked.OnClick(this.gameObject);
                }
                
            }

        }

        // i am holding a click
        if (holdingClick && lastClicked != null)
        {
            RaycastHit2D hit = FireRay();
            if (hit.collider == null)
            {
                ClearClickState();
            }
        }
        // I have ended a click
        if (endedClick)
        {
            ClearClickState();
        }
    }

    private RaycastHit2D FireRay()
    {
        //Vector3 origin = isAlive ? Input.mousePosition : this.transform.position;

        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(origin);
        //Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);


        //keep an eye out for clicks not working as you go up in floors

        Vector2 mousePos2D = new Vector2(this.transform.position.x, this.transform.position.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        return hit;
    }
    private void ClearClickState()
    {
        if (lastClicked != null)
        {
            //lastClicked.BroadcastMessage("OnRelease", this.gameObject);
            lastClicked.OnRelease(this.gameObject);
            lastClicked = null;
        }
    }

}
