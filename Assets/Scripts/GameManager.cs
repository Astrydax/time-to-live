using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera;
    public bool gamePlaying = false;

    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in scene");
        }
        instance = this;
    }

    private void Start()
    {
        mainCamera.transform.position = new Vector3(0, -10, -10);
        // subscribe to events
        GameEventsManager.instance.onGameStart += OnGameStart;
    }

    private void OnDestroy()
    {
        // unsubscribe from events
        GameEventsManager.instance.onGameStart -= OnGameStart;
    }


    public void OnGameStart()
    {
        GameEventsManager.instance.GameStart();
        mainCamera.transform.position = new Vector3(0, 0, -10);
        gamePlaying = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
