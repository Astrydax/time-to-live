using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in scene");
        }
        instance = this;
    }

    public event Action onPlayerRespawn;

    public void PlayerRespawned()
    {
        if (onPlayerRespawn != null)
        {
            onPlayerRespawn();
        }
    }

    public event Action onRestartGame;

    public void RestartGame()
    {
        if (onRestartGame != null)
        {
            onRestartGame();
        }
    }

    public event Action onGameStart;

    public void GameStart()
    {
        if (onGameStart != null)
        {
            onGameStart();
        }
    }


}
