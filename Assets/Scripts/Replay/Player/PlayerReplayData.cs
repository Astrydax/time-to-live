using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReplayData : ReplayData
{
    public bool startedClick { get; private set; }
    public bool holdingClick { get; private set; }
    public bool endedClick { get; private set; }
    public PlayerReplayData(Vector3 position, bool startedClick, bool holdingClick, bool endedClick)
    {
        this.position = position;
        this.startedClick = startedClick;
        this.holdingClick = holdingClick;
        this.endedClick = endedClick;
    }
}
