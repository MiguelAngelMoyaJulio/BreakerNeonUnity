using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("LEVEL1");
    }

    public void menuGame()
    {
        SceneManager.LoadScene("MENU");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadOption()
    {
        SceneManager.LoadScene("OPTION");
    }
}