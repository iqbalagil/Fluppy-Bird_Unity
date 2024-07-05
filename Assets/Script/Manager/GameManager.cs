using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startGame;
    public player player;
    public GameObject titleGame;

    public GameObject inGameUI;

    public GameObject resumeButton;
    public GameObject pauseButton;

    public GameObject gameOverOvelays;
    public float timeCountdown = 3;

    void Start()
    {
        gameOverOvelays.gameObject.SetActive(false);
        //inGameUI.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    void Update()
    {
        if (player.isDead)
        {
            gameOverOvelays.gameObject.SetActive(true);
            GameOver();
        }
    }

    public void StartGame()
    {

            titleGame.gameObject.SetActive(false);
            startGame.gameObject.SetActive(false);
        //inGameUI.gameObject.SetActive(true);
            Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }

    public void GameResume()
    {
        if(resumeButton == true)
        {
            resumeButton.gameObject.SetActive(false);
            Time.timeScale = 1;
            pauseButton.gameObject.SetActive(true);
        }
    }

    public void GamePause()
    {
        if(pauseButton == true)
        {
            pauseButton.gameObject.SetActive(false);
            Time.timeScale = 0;
            resumeButton.gameObject.SetActive(true);
        }
    } 

    public void LoadGame()
    {

    }
}
