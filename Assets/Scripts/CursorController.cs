using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    public bool isAlive;
    private Recorder recorder;
    public ClickStates clickStates;

    public string firstName;
    public Sprite sprite;

    public float lifespan;
    public float lifespanCounter;
    public Slider lifeSpanSlider;

    private LifeController lifeController;

    


    public TMP_Text nameTag;
    public SpriteRenderer sr;

    public GameObject lastClicked;

    private void Awake()
    {
        recorder = GetComponent<Recorder>();
        clickStates = GetComponent<ClickStates>();
        clickStates.isAlive = isAlive;
        lifespanCounter = lifespan;
       /* lifeSpanSlider.maxValue = lifespan;
        lifeSpanSlider.minValue = 0;*/
    }

    

    private void OnDestroy()
    {
    }

    private void Start()
    {
        nameTag.text = name;
        sr.sprite = sprite;
        Cursor.visible = false;
        lifeController = GetComponent<LifeController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        lifespanCounter -= Time.deltaTime;
        //lifeSpanSlider.value = lifespanCounter;
        if(lifespanCounter <= 0)
        {
            lifespanCounter = lifespan;
            HandleDeath();
        }

        if (isAlive)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;

            // logic used to statifying the mouse inputs for replays

            //initialize state to false until checked
            clickStates.startedClick = false;

            //constantly gather click
            clickStates.holdingClick = Input.GetMouseButton(0);

            //initialize state to false until checked
            clickStates.endedClick = false;

            if (Input.GetMouseButtonDown(0))
            {
                clickStates.startedClick = true;
            }            
            // I have ended a click
            if (Input.GetMouseButtonUp(0))
            {
                clickStates.endedClick = true;
            }
        }
    }

    private void HandleDeath()
    {
        if (!GameManager.instance.gamePlaying)
        {
            GameEventsManager.instance.GameStart();
        }
        lifeController.LoseLife();

        if (GameManager.instance.victory == true)
        {
            GameManager.instance.Victory();
            return;
        }
        
        if(lifeController.playerLives < 0)
        {
            GameManager.instance.GameOver();

            return;
        }
        

        //destroy old ghosts
        PlayerReplayObject[] ghosts = FindObjectsOfType<PlayerReplayObject>();
        foreach (PlayerReplayObject playerReplayObject in ghosts)
        {
            Destroy(playerReplayObject.gameObject);
        }
        GameEventsManager.instance.PlayerRespawned();

        Camera.main.transform.position = new Vector3(0, 0, Camera.main.transform.position.z);        
    }

    private void LateUpdate()
    {
        ReplayData data = new PlayerReplayData(this.transform.position, clickStates.startedClick, clickStates.holdingClick, clickStates.endedClick);
        recorder.RecordReplayFrame(data);
    }

    private RaycastHit2D FireRay()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        return hit;
    }   
}
