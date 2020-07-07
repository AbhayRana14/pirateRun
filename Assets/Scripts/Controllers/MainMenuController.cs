using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        GameManage.instance.playerDiedGameRestarted = false;
        SceneManager.LoadScene("Gameplay");
    }
}
