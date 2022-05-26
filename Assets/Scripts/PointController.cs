using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : ClickableObject
{
    public GameObject pointEffect;

    public int pointValue = 10;

    

    public override void OnClick(GameObject clicker)
    {
        GameManager.instance.collectedPoints += pointValue;
        this.gameObject.SetActive(false);
        GameObject effect = Instantiate(pointEffect, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity); 
        

    }

    public override void OnRelease(GameObject clicker)
    {
        //when the object is released
    }

   
}
