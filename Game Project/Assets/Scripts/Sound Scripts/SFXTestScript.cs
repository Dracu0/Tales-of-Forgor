using System.Collections;
using UnityEngine;

public class SFXTestScript : MonoBehaviour
{
    [SerializeField] private AudioSource soundToTriggerSource;
    [SerializeField] private AudioClip[] soundToTrigger;
    [SerializeField] private SpriteRenderer SpriteOnTrigger;
    [SerializeField] private Animator anim;
    [SerializeField] private Animation[] FadeAnimationTrigger;
    [SerializeField] private float SFXTriggerVolume;
    [SerializeField] private float DelayBetweenClips;
    [SerializeField] private float DelayBetweenAnimations;
    [SerializeField] private float DelayToDestroy;
    [SerializeField] private bool destroyOnDelay;
    [SerializeField] private bool isTriggered;
    [SerializeField] private bool isReplayable;
    int count = 1;

    private void Start()
    {
        SFXTriggerVolume = 0.5f;
        SpriteOnTrigger = this.GetComponent<SpriteRenderer>();
        SpriteOnTrigger.enabled = false;
        soundToTriggerSource.volume = SFXTriggerVolume;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isTriggered = true;

            if (isTriggered && count == 1)
            {
                SpriteOnTrigger.enabled = true;
                StartCoroutine(PlayMultipleSFX());
            }
            if (isReplayable == true && isTriggered && count == 1)
            {
                SpriteOnTrigger.enabled = true;
                StartCoroutine(PlayMultipleSFX());
            }
            if (isReplayable == false)
            {
                if (count == 1)
                {
                    StartCoroutine(PlayMultipleSFX());
                    SpriteOnTrigger.enabled = true;
                    count = 0;
                }
                if (count == 0)
                {
                    SpriteOnTrigger.enabled = true;
                    count = 0;
                }
            }
        }
        Debug.Log(count);
    }

    IEnumerator PlayMultipleSFX()
    {
        for (int i = 0; i < soundToTrigger.Length; i++)
        {
            AudioClip clip = soundToTrigger[i];
            soundToTriggerSource.PlayOneShot(clip, SFXTriggerVolume);
            if (i == soundToTrigger.Length - 1)
            {
                yield return new WaitForSeconds(clip.length);
            }
            else
            {
                yield return new WaitForSeconds(DelayBetweenClips);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isReplayable)
            {
                SpriteOnTrigger.enabled = false;
                isTriggered = false;
                count = 1;
            }
            else
            {
                SpriteOnTrigger.enabled = true;
                isTriggered = false;
                Destroy(this.gameObject, DelayToDestroy);
                count = 0;
            }
            Debug.Log(count);
        }
    }
}