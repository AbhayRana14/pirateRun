using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    private Text scoreText;
    private Text lifeText;

    private int score;
    private int lifeScore;


    // Start is called before the first frame update
    void Awake()
    {
        makeInstance();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
           
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene,LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            if (!GameManage.instance.playerDiedGameRestarted)
            {
                score = 0;
                lifeScore = 2;

            }
            else {
                score = GameManage.instance.Score;
                lifeScore = GameManage.instance.lifeScore;

            }
            scoreText.text = "x" + score;
            lifeText.text = "x" + lifeScore;
        }
    }
    private void makeInstance()
    {
        if (instance == null)
        {
            instance = this;

             
        }
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = "x" + score;
        
    }
    public void DecrementLife()
    {
        lifeScore--;
        if (lifeScore >= 0)
        {
            lifeText.text = "x" + lifeScore;
        }
        StartCoroutine(PlayerDied());
    }

    IEnumerator PlayerDied()
    {
        yield return new WaitForSeconds(2f);

        if (lifeScore < 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else {
            GameManage.instance.playerDiedGameRestarted = true;
            GameManage.instance.Score = score;
            GameManage.instance.lifeScore = lifeScore;
            SceneManager.LoadScene("Gameplay");


        }
    }

}
