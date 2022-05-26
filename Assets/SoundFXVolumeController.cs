using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXVolumeController : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        float distancefromCamera =  Mathf.Floor(Mathf.Abs(this.transform.position.y - Camera.main.transform.position.y)/10)*10;
        
        

        if(distancefromCamera == 0f)
        {
            audioSource.volume = 1f;
        }else if(distancefromCamera == 10f)
        {
            audioSource.volume = 0.75f;
        }else if(distancefromCamera == 20f)
        {
            audioSource.volume = 0.25f;
        }
        else
        {
            audioSource.volume = 0f;
        }
        Debug.Log("DistanceFromCamera: " + distancefromCamera + " Volume Set to: " + audioSource.volume);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
