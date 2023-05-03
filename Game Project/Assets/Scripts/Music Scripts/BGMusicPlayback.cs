using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGMusicPlayback: MonoBehaviour
{
    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("startBGMusic"))
        {
            BGMusic.instance.GetComponent<AudioSource>().Play();
        }
        if (collision.CompareTag("resumeBGMusic"))
        {
            BGMusic.instance.GetComponent<AudioSource>().UnPause();
        }
        if (collision.CompareTag("pauseBGMusic"))
        {
            BGMusic.instance.GetComponent<AudioSource>().Pause();
        }
        if (collision.CompareTag("stopBGMusic"))
        {
            BGMusic.instance.GetComponent<AudioSource>().Stop();
        }
    }*/

    public void PlayMusic()
    {
        BGMusic.instance.GetComponent<AudioSource>().Play();
    }
    public void ResumeMusic()
    {
        BGMusic.instance.GetComponent<AudioSource>().UnPause();
    }
    public void PauseMusic()
    {
        BGMusic.instance.GetComponent<AudioSource>().Pause();
    }
    public void StopMusic()
    {
        BGMusic.instance.GetComponent<AudioSource>().Stop();
    }
}
