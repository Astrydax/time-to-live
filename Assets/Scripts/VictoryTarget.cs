using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTarget : PointController
{
    public override void OnClick(GameObject clicker)
    {
        GameManager.instance.victory = true;

        base.OnClick(clicker);
    }

    public override void OnRelease(GameObject clicker)
    {
        return;
    }
}
