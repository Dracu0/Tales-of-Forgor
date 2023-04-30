using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicPlay : MonoBehaviour
{
    public Text musicSliderText;
    public Slider volumeSlider;

    private float musicVolume = 0.3f;
    private AudioSource bgMusic;

    private void Start()
    {
        bgMusic = BGMusic.instance.GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("volume");
        bgMusic.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    public void Update()
    {
        bgMusic.volume = musicVolume;
        musicSliderText.text = "Volume: " + Mathf.RoundToInt(volumeSlider.value * 100) + "%";
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void VolumeUpdater()
    {
        musicVolume = volumeSlider.value;
    }

    public void MusicReset()
    {
        bgMusic.volume = 1;
        volumeSlider.value = 1;
    }
}