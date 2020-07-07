using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    public bool isAlive;
    private GameObject gameFinishedText;

     
    // Start is called before the first frame update
    void Awake()   
    {
        isAlive = true;
        gameFinishedText = GameObject.Find("LevelFinished");
        gameFinishedText.SetActive(false);

     

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Collectable")
        {
            GamePlayController.instance.IncrementScore();
            target.gameObject.SetActive(false);
        }
        if (target.tag == "Skeleton")
        {
            if (isAlive)
            {
               
                isAlive = false;
                GamePlayController.instance.DecrementLife();
                transform.position = new Vector3(0, 100000, 0);
            }
        }
        if (target.tag == "Exit")
        {
            gameFinishedText.SetActive(true);
            Time.timeScale = 0f; 
        }
    }
}
