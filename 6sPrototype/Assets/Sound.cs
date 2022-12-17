using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider UISlider;
    [SerializeField] AudioSource mainMusic;
    [SerializeField] AudioSource clickSFX;
    [SerializeField] AudioSource phoneSFX;
    [SerializeField] AudioSource fanSFX;
    
    void Update()
    {
        mainMusic.volume = .5f*(musicSlider.value * masterVolumeSlider.value);
        clickSFX.volume = UISlider.value * masterVolumeSlider.value;
        phoneSFX.volume = SFXSlider.value * masterVolumeSlider.value;
        fanSFX.volume = SFXSlider.value * masterVolumeSlider.value;
    }


}
