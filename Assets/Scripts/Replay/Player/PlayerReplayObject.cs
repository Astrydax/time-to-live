using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReplayObject : ReplayObject
{
    private ClickStates clickSates;

    private void Awake()
    {
        clickSates = GetComponent<ClickStates>();
    }

    public override void SetDataForFrame(ReplayData data)
    {
        //typecast the data
        PlayerReplayData playerData = (PlayerReplayData)data;
        this.transform.position = playerData.position;
        clickSates.startedClick = playerData.startedClick;
        clickSates.holdingClick = playerData.holdingClick;
        clickSates.endedClick = playerData.endedClick;
    }
}
