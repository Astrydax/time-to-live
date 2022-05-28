using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ClickableObject
{

    [Header("Object To Spawn")]
    public GameObject contents;
    protected GameObject instantiatedObjectRef;
    public bool destoryContentsOnLoop = true;

    [Header("Used by prefab")]
    [SerializeField] private Transform contentSpawnPoint;
    public GameObject opened, unopened;
    protected PolygonCollider2D _collider;



   
    public virtual void Start()
    {
        unopened.SetActive(true);
        opened.SetActive(false);

        _collider = GetComponent<PolygonCollider2D>();
        GameEventsManager.instance.onPlayerRespawn += OnPlayerRespawn;
    }

    private void OnDestroy()
    {
        // unsubscribe from events
        GameEventsManager.instance.onPlayerRespawn -= OnPlayerRespawn;
    }

    protected virtual void OnPlayerRespawn()
    {
        _collider.enabled = true;
        unopened.SetActive(true);
        opened.SetActive(false);
        if (destoryContentsOnLoop)
        {
            Destroy(instantiatedObjectRef);
        }
        
    }

    public override void OnClick(GameObject clicker)
    {
        _collider.enabled = false;
        unopened.SetActive(false);
        opened.SetActive(true);

        
        ShowContents(clicker);
    }

    public virtual void ShowContents(GameObject clicker)
    {
        if (clicker.GetComponent<ClickStates>().isAlive)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
        
        //Depening how loop restarting goes in the game manager, we may just swith this to childed objects that are hidden
        if (contents != null)
        {
            instantiatedObjectRef = Instantiate(contents, contentSpawnPoint);
            
        }    
    }

    public override void OnRelease(GameObject clicker)
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
