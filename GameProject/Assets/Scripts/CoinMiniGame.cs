using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinMiniGame : MonoBehaviour
{
    [SerializeField] private float MaxWidth;
    public float waitingTime;

    public GameObject coin;

    public void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (Coin.totalCoins < 15)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-MaxWidth, MaxWidth), transform.position.y, 0.0f);
            Instantiate(coin, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(waitingTime);
        }
        if(Coin.totalCoins == 15)
        {
            SceneManager.LoadScene("Scenes/Menu/WinScreen");
        }
    }

    /*IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        GameObject newCoin = Instantiate(coin[Random.Range(0, coin.Length)], this.transform);
        newCoin.transform.localPosition = new Vector3(Random.Range(-MaxWidth, MaxWidth), 0.08f, 0);
    }*/

}
