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
    public GameObject winScreen;
    public GameObject breakevenScreen;
    public GameObject loseScreen;
    AudioManager AM;
    int score;
    int winScore = 10;
    public bool gameOver = false;

    public void Start()

    {
        Time.timeScale = 1;
        AM = FindObjectOfType<AudioManager>();
        menuPanel.SetActive(false);
  //      AM.Play("VideoGameMusic");

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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            AM.Stop("VideoGameMusic");
            AM.Play("MedievalMusic");
        }
        if (gameOver)
        {
            menuPanel.SetActive(true);
            if (score >= winScore)
            {
                winScreen.SetActive(true);
                pausePanel.SetActive(false);
                breakevenScreen.SetActive(false);
                loseScreen.SetActive(false);
                AM.PlayOneShot("WinAudio");
            }
            if (score < winScore && score >= 0)
            {
                winScreen.SetActive(false);
                pausePanel.SetActive(false);
                breakevenScreen.SetActive(true);
                loseScreen.SetActive(false);
                AM.PlayOneShot("Breakeven");
            }
            if (score < 0)
            {
                AM.PlayOneShot("LoseAudio");
                winScreen.SetActive(false);
                pausePanel.SetActive(false);
                breakevenScreen.SetActive(false);
                loseScreen.SetActive(true);
            }
        }
    }

    public void GameResume()
    {
        Cursor.lockState = CursorLockMode.Locked;
  //      Cursor.visible = false;
        menuPanel.SetActive(false);
        AM.Stop("MedievalMusic");
        AM.Play("VideoGameMusic");
        Time.timeScale = 1;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        winScreen.SetActive(false);
        breakevenScreen.SetActive(false);
        loseScreen.SetActive(false);
        menuPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AM.Stop("MedievalMusic");
        AM.Play("VideoGameMusic");
        Time.timeScale = 1;
    }

    public void ReallyQuit()
    {
        Application.Quit();
    }

}
