﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainmenuPanel;

    // Start is called before the first frame update
    public void Start()
    {
        SceneManager.LoadScene(1);
        MainmenuPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioManager.instance.Play("VideoGameMusic");
        Time.timeScale = 1;
    }

}