using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartMG : MonoBehaviour
{
    [SerializeField] private AudioSource heartSound;
    [SerializeField] private SpriteRenderer mgSprite;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            heartSound = GetComponent<AudioSource>();
            heartSound.Play();
            Destroy(this.gameObject, 1);
            PlayerCoinMiniGameHeal(35);
        }

        if (collision.CompareTag("CoinDestroyer"))
        {
            mgSprite.enabled = false;
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