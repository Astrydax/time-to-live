using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStates : MonoBehaviour
{
    public bool startedClick, holdingClick, endedClick;

    public bool isAlive = false;

    private GameObject lastClicked;

    public GameObject clickFX;

    

    private void Update()
    {
        if (startedClick)
        {
            GameObject fx = Instantiate(clickFX, this.transform);
            fx.transform.parent = null;
        }
        
        if (startedClick && lastClicked == null)
        {
            Debug.Log("You Clicked!");
            RaycastHit2D hit = FireRay();
            if (hit.collider != null)
            {
                lastClicked = hit.collider.gameObject;
                hit.collider.gameObject.BroadcastMessage("OnClick", this.gameObject);
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
            lastClicked.BroadcastMessage("OnRelease", this.gameObject);
            lastClicked = null;
        }
    }

}
