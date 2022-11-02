/*****************************************************************************
// File Name :         NewPauseMenu.cs
// Author :            Morgan Harrell
// Creation Date :     20 October 2022
//
// Brief Description : Handles the simple in-game pause menu
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPauseMenu : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The pause menu gameobject")]
    private GameObject pauseMenu = null;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
