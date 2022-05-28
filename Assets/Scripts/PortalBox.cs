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


        ShowContents();
        Destroy(this.gameObject);
    }
    public override void ShowContents()
    {
        base.ShowContents();
        instantiatedObjectRef.transform.SetParent(null);
    }

}
