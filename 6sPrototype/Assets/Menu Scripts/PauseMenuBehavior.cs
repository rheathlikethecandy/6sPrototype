/*****************************************************************************
// File Name :         PauseMenuBehavior.cs
// Author :            Morgan Harrell
// Creation Date :     15 September 2022
//
// Brief Description : Handles the pause menu and allows players to pause the game.
*****************************************************************************/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class PauseMenuBehavior : MenuBehavior
{
    #region Variables
    /// <summary>
    /// Holds true if the game is currently paused.
    /// </summary>
    public static bool isPaused = false;

    /// <summary>
    /// Enables and disables the pause feature.
    /// </summary>
    private bool canPause = false;

    private bool canClosePauseMenu = true;

    public GameObject rekeybindOverlay;

    /// <summary>
    /// 
    /// </summary>
    public bool CanPause
    {
        get => canPause;
        set
        {
            canPause = value;
        }
    }

    [Space]
    [SerializeField]
    [Tooltip("The pause menu gameobject")]
    private GameObject pauseMenu = null;

    [SerializeField]
    private GameObject towerStats;
    public static GameObject TowerStats;

    public static Transform OverviewPositionObj;
    public static Transform OverviewCursor;
    #endregion

    #region Functions
    /// <summary>
    /// Initializes components.
    /// </summary>
    private void Awake()
    {
        //vCam = GameObject.Find("PlayerFollowCamera").GetComponent<CinemachineVirtualCamera>(); ;
        //vCams = GameObject.FindObjectsOfType<CinemachineVirtualCamera>();
        OverviewCursor = GameObject.Find("Cursor").transform;
        OverviewPositionObj = GameObject.Find("CursorPos").transform;
        OverviewPositionObj.position = Camera.main.transform.position + new Vector3(-76, 0, 475);
        StartCoroutine(WaitFadeIn());
    }

    private IEnumerator WaitFadeIn()
    {
        yield return new WaitForSeconds(crossfadeAnim.GetCurrentAnimatorStateInfo(0).length);

        canPause = true;
    }

    bool wasActiveBefore = false;
    /// <summary>
    /// If the player hits the pause game key, the game is paused.
    /// </summary>
    public void PauseGame()
    {
        // Opens pause menu and pauses the game
        if (canPause && canClosePauseMenu)
        {
            StartCoroutine(WaitToUnpause());
        }
    }

    private IEnumerator WaitToUnpause()
    {
        yield return new WaitForSeconds(0.001f);
        PauseAim();
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        AudioListener.pause = isPaused;

        if (isPaused)
        {
            if (Cursor.lockState == CursorLockMode.Confined)
            {
                wasActiveBefore = true;
            }
            else
            {
                wasActiveBefore = false;
            }
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else if (!wasActiveBefore)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }



    private void PauseAim()
    {
        //if (GlobalValues.isInOverview) return;
        return;
    }

    public void CanClosePauseMenu(bool canClose)
    {
        canClosePauseMenu = canClose;
    }

    /// <summary>
    /// Restarts the current level from the beginning.
    /// </summary>
    public void RestartLevel()
    {
        //canPause = false;
    }

    public void LeaveRoom()
    {
        isPaused = false;
        //PhotonNetwork.LeaveRoom();
    }
    #endregion
}