using UnityEngine;
using UnityEngine.SceneManagement;

public class MGPortalUnlock : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private bool MGPortalUnlocked;
    [SerializeField] private int CoinsToUnlock;
    private int MiniGameCoins;

    private void Awake()
    {
        MiniGameCoins = PlayerPrefs.GetInt("MiniGameCoins");
        Debug.Log(MiniGameCoins);
    }

    void Update()
    {
        if (MiniGameCoins < CoinsToUnlock)
        {
            MGPortalUnlocked = false;
            IsUnlocked();
        }
        if (MiniGameCoins >= CoinsToUnlock)
        {
            MGPortalUnlocked = true;
            IsUnlocked();
        }
    }

    public void IsUnlocked()
    {
        if(MGPortalUnlocked == false)
        {
            gameObject.SetActive(false);
            GetComponent<Collider2D>().isTrigger = false;
        }
        if (MGPortalUnlocked == true)
        {
            gameObject.SetActive(true); 
            GetComponent<Collider2D>().isTrigger = true;
        }
    } 

    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(sceneName);
    }
}
