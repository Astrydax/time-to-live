using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public int playerLives;
    [SerializeField] private Image[] lifeImages;
    public GameObject loseLifeFX;


    private void Start()
    {
        UpdateLives();
    }

    public void UpdateLives()
    {

        for(int i= 0; i <lifeImages.Length; i++)
        {
            if(i < playerLives)
            {
                lifeImages[i].enabled = true;
            }
            else
            {
                lifeImages[i].enabled = false;
                
            }
        }
    }

    public void LoseLife()
    {
        playerLives--;
        if(playerLives < 0)
        {
            GameManager.instance.gamePlaying = false;

            //add gameover screen handler here, for now just return
            return;
        }
        if (loseLifeFX != null)
        {
            lifeImages[playerLives].enabled = false;
            GameObject effect = Instantiate(loseLifeFX, lifeImages[playerLives].transform);
            
        }

    }
}
