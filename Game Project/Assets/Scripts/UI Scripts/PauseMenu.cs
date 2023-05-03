using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenu;
    public static bool GameIsPaused = false;
    private AudioSource[] allAudioSources;

    private void Start()
    {
        pauseMenu = GetComponent<Canvas>();
        pauseMenu.enabled = false;
        PlayerPrefs.GetInt("MiniGameCoins");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ResumeGame()
    {
        Resume();
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Menu/Menu", LoadSceneMode.Single);
        Coin.totalCoins = 0;
        pauseMenu.enabled= false;   
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
    }

    public void ResetCoins()
    {
        Coin.totalCoins = 0;
        PlayerPrefs.SetInt("MiniGameCoins", Coin.totalCoins);
        Debug.Log(Coin.totalCoins);
    }

    void Resume()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        allAudioSources = Resources.FindObjectsOfTypeAll(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.UnPause();
        }
    }

    void Pause()
    {
        pauseMenu.enabled = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;

        allAudioSources = Resources.FindObjectsOfTypeAll(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Pause();
        }

    }

}
