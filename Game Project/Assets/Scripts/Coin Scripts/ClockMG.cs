using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockMG : MonoBehaviour
{
    [SerializeField] private AudioSource clockSound;
    [SerializeField] private SpriteRenderer mgSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clockSound = GetComponent<AudioSource>();
            clockSound.Play();
            Destroy(this.gameObject, 1);
            CoinMiniGame.TimeLeft += 5.0f; 
        }

        if (collision.CompareTag("CoinDestroyer"))
        {
            mgSprite.enabled = false;
            Destroy(this.gameObject, 2);
        }
    }
}