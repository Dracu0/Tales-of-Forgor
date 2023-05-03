using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinMG : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject, 2);
        }

        if (collision.CompareTag("CoinDestroyer"))
        {
            Destroy(this.gameObject, 2);
            PlayerCoinMiniGameTakeDamage(10);
        }
    }
    private void PlayerCoinMiniGameTakeDamage(int damage)
    {
        GameManager.gameManager.playerHealth.DamageUnit(damage);
    }

    private void PlayerCoinMiniGameHeal(int healing)
    {
        GameManager.gameManager.playerHealth.HealUnit(healing);
    }

}