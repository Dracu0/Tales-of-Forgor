using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Canvas pauseMenu;
    public static bool GameIsPaused = false;

    private void Start()
    {
        pauseMenu = GetComponent<Canvas>();
        pauseMenu.enabled = false;
        GameIsPaused = false;
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
        //Debug.Log(GameIsPaused);
        //Debug.Log(pauseMenu);
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
        GameIsPaused = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

    void Resume()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenu.enabled = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

}
