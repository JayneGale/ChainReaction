using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public KeyCode PauseKey;
    public GameObject menuPanel;
    public GameObject pausePanel;
    public GameObject endScreen;
    public GameObject winScreen;
    public GameObject breakevenScreen;
    public GameObject loseScreen;

    public int score = -10;
    public int winScore = 10;
    bool gameOver = false;

    public Text timeRemaining;
    public float timeRemains;
    float tempTimeRemains;
    int timeInt;
    bool timeOn;
    
    public void Start()

    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        timeRemaining.text = "" + timeRemains;
        timeOn = true;
        tempTimeRemains = timeRemains;
        AudioManager.instance.Play("VideoGameMusic");

    }

    private void Update()
    {
        if (Input.GetKeyDown(PauseKey))
        {
            menuPanel.SetActive(true);
            pausePanel.SetActive(true);
            winScreen.SetActive(false);
            breakevenScreen.SetActive(false);
            loseScreen.SetActive(false);
            endScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            AudioManager.instance.Stop("VideoGameMusic");
            AudioManager.instance.Play("MedievalMusic");
        }

        if (timeOn == true)
        {
            tempTimeRemains -= Time.deltaTime;
            timeInt = (int)tempTimeRemains;
            timeRemaining.text = "Time left: " + timeInt;
        }

        if (timeInt <= 0)
        {
            timeOn = false;
            tempTimeRemains = 0;
            timeRemaining.text = "" + tempTimeRemains;
            gameOver = true;
        }

        if (gameOver)
        {
            menuPanel.SetActive(true);
            endScreen.SetActive(true);
            Time.timeScale = 0;
            if (score >= winScore)
            {
                winScreen.SetActive(true);
                breakevenScreen.SetActive(false);
                loseScreen.SetActive(false);
                pausePanel.SetActive(false);
                AudioManager.instance.Play("WinAudio");
            }

            if (score < winScore && score >= 0)
            {
                winScreen.SetActive(false);
                breakevenScreen.SetActive(true);
                loseScreen.SetActive(false);
                pausePanel.SetActive(false);
                AudioManager.instance.Play("Breakeven");
            }

            if (score < 0)
            {
                AudioManager.instance.Play("LoseAudio");
                winScreen.SetActive(false);
                pausePanel.SetActive(false);
                breakevenScreen.SetActive(false);
                loseScreen.SetActive(true);
            }
        }
    }

    public void GameResume()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        pausePanel.SetActive(false);
        endScreen.SetActive(false);
        AudioManager.instance.Stop("MedievalMusic");
        AudioManager.instance.Play("VideoGameMusic");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        winScreen.SetActive(false);
        breakevenScreen.SetActive(false);
        loseScreen.SetActive(false);
        menuPanel.SetActive(false);
        endScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioManager.instance.Stop("MedievalMusic");
        AudioManager.instance.Play("VideoGameMusic");
        Time.timeScale = 1;
    }

    public void ReallyQuit()
    {
        Application.Quit();
    }

}
