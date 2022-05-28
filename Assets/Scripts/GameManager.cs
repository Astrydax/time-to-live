using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera;
    public bool gamePlaying = false;

    public int collectedPoints = 0;
    public TMP_Text pointDisplay;
    public GameObject[] objectsToReset;

    public GameObject hud;
    public GameObject startScreenCounter;

    public Box[] guessBoxes;
    public GameObject guessBoxContent;

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
        // subscribe to events
        GameEventsManager.instance.onGameStart += OnGameStart;
        GameEventsManager.instance.onPlayerRespawn += OnPlayerRespawn;

        mainCamera.transform.position = new Vector3(0, -10, -10);

        objectsToReset = GameObject.FindGameObjectsWithTag("Resetable");



    }

    private void OnDestroy()
    {
        // unsubscribe from events
        GameEventsManager.instance.onGameStart -= OnGameStart;
        GameEventsManager.instance.onPlayerRespawn -= OnPlayerRespawn;
    }


    public void OnGameStart()
    {        
        if(gamePlaying == true)
        {
            return;
        }
        gamePlaying = true;
        hud.SetActive(true);
        startScreenCounter.SetActive(false);

        int r = Random.Range(0, guessBoxes.Length);
        guessBoxes[r].contents = guessBoxContent;


    }

    private void OnPlayerRespawn()
    {
        collectedPoints = 0;
        foreach(GameObject obj in objectsToReset)
        {
            obj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pointDisplay.text = "Points: " + collectedPoints.ToString();
    }

}
