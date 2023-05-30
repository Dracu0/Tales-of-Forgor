using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusic : MonoBehaviour
{
    public static BGMusic instance;
    [SerializeField] private bool DestroyBGMusic;

    public void Awake()
    {
        if(DestroyBGMusic == true)
        {
            instance = this;
        }
        if(DestroyBGMusic == false)
        {
            if (instance != null)
                Destroy(gameObject);
            else
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }
         
    }
}
