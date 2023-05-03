using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGPortalUnlock : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private bool MGPortalUnlocked;
    private int MiniGameUnlock;

    private void Awake()
    {
        MiniGameUnlock = PlayerPrefs.GetInt("MiniGameCoins");
        Debug.Log(MiniGameUnlock);
    }

    void Update()
    {
        if (MiniGameUnlock == 0)
        {
            MGPortalUnlocked = false;
            this.gameObject.SetActive(false);
        }

        if (MiniGameUnlock >= 15)
        {
            MGPortalUnlocked = true;
            this.gameObject.SetActive(true);
        }
    }

    /*
    public void SecretPortalUnlocked()
    {

    }
    */

    void OnTriggerEnter2D(Collider2D col)
    {
        if(tag == "Player")
        {
           SceneManager.LoadScene(sceneName);
        }
    }
}
