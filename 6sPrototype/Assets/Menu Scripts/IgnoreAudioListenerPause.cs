/*****************************************************************************
// File Name :         IgnoreAudioListenerPause.cs
// Author :            Morgan Harrell
// Creation Date :     15 September 2022
//
// Brief Description : Does not let this objects audiosource be paused by the
                       AudioListener.
*****************************************************************************/
using UnityEngine;

public class IgnoreAudioListenerPause : MonoBehaviour
{
    /// <summary>
    /// Causes this audiosource to not be paused by the audiolistener.
    /// </summary>
    private void Awake()
    {
        GetComponent<AudioSource>().ignoreListenerPause = true;
    }
}