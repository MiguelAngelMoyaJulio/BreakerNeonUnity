using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject menuPause;

    private void Update()
    {
        pauseGame();
    }

    private void pauseGame()
    {
        GameObject audio = GameObject.Find("music");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            audio.GetComponent<AudioSource>().Pause();
            Time.timeScale = 0f;
            menuPause.SetActive(true);
        }
    }

    public void unpauseGame()
    {
        GameObject audio = GameObject.Find("music");
        Time.timeScale = 1f;
        menuPause.SetActive(false);
        audio.GetComponent<AudioSource>().Play();
    }

    public void menu()
    {
        Time.timeScale = 1f;
        menuPause.SetActive(false);
        SceneManager.LoadScene("MENU");
        if (GameObject.Find("GM") != null)
        {
            Destroy(GameObject.Find("GM"));
        }
    }
}