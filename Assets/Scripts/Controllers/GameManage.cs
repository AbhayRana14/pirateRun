using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage instance;

    public int Score;
    public int lifeScore;
    public bool playerDiedGameRestarted;

    void Awake()
    {
        MakeSingleton(); 
    }
    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
