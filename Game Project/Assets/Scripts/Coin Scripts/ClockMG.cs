using UnityEngine;

public class ClockMG : MonoBehaviour
{
    [SerializeField] private AudioSource clockSound;
    [SerializeField] private SpriteRenderer mgSprite;
    [SerializeField] private float extraTime = 8.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clockSound = GetComponent<AudioSource>();
            clockSound.Play();
            Destroy(this.gameObject, 1);
            CoinMiniGame.TimeLeft += extraTime;
        }

        if (collision.CompareTag("CoinDestroyer"))
        {
            mgSprite.enabled = false;
            Destroy(this.gameObject, 2);
        }
    }
}