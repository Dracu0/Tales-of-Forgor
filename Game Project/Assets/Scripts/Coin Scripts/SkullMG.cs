using UnityEngine;
using UnityEngine.SceneManagement;

public class SkullMG : MonoBehaviour
{
    [SerializeField] private AudioSource skullSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skullSound = GetComponent<AudioSource>();
            skullSound.Play();
            Destroy(this.gameObject, 2);
            PlayerCoinMiniGameTakeDamage(25);
        }

        if (collision.CompareTag("CoinDestroyer"))
        {
            Destroy(this.gameObject, 2);
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