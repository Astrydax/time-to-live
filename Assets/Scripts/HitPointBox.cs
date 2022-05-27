using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitPointBox : Box
{
    public int maxHitpoints;
    public int currentHitpoints;

    [SerializeField] private TMP_Text hitPointText;

    public override void Start()
    {
        currentHitpoints = maxHitpoints;
        hitPointText.text = currentHitpoints.ToString();
        base.Start();
    }
    public override void OnClick(GameObject clicker)
    {
        currentHitpoints--;
        hitPointText.text = currentHitpoints.ToString();
        if(currentHitpoints <= 0)
        {            
            hitPointText.enabled = false;
            base.OnClick(clicker);
        }
        
    }

    protected override void OnPlayerRespawn()
    {
        currentHitpoints = maxHitpoints;
        hitPointText.text = currentHitpoints.ToString();
        hitPointText.enabled = true;
        base.OnPlayerRespawn();
    }

    public override void OnRelease(GameObject clicker)
    {
        base.OnRelease(clicker);
    }

}
