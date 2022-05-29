using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBox : Box
{   
    public override void OnClick(GameObject clicker)
    {
        _collider.enabled = false;
        unopened.SetActive(false);
        opened.SetActive(true);


        ShowContents(clicker);
        Destroy(this.gameObject);
    }
    public override void ShowContents(GameObject clicker)
    {
        base.ShowContents(clicker);
        instantiatedObjectRef.transform.SetParent(null);
    }

}
