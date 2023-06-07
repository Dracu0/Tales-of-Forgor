using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoundTriggerWithSprite : MonoBehaviour
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
    [SerializeField] private bool isReplayable;
    private bool isTriggered;
    int count = 1;

    private void Start()
    {
        SFXTriggerVolume = 0.5f;
        SpriteOnTrigger = this.GetComponent<SpriteRenderer>();
        SpriteEnable(true);
        soundToTriggerSource.volume = SFXTriggerVolume;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
         if (col.CompareTag("Player"))
         {
            isTriggered = true;

            if (isTriggered && count == 1)
            {
                SpriteEnable(true);
                StartCoroutine(PlayMultipleSFX());
            }
            if (isReplayable == true && isTriggered && count == 1)
            {
                SpriteEnable(true);
                StartCoroutine(PlayMultipleSFX());
            }
            if (isReplayable == false)
            {
                if (count == 1)
                {
                    StartCoroutine(PlayMultipleSFX());
                    SpriteEnable(true);
                    count = 0;
                }
                if (count == 0)
                {
                    SpriteEnable(true);
                    count = 0;
                }
            }
        }
        //Debug.Log(count);
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

    private void SpriteEnable(bool state)
    {
        if (SpriteOnTrigger != null)
        {
            SpriteOnTrigger.enabled = state;
        }
        else
        {
            return;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isReplayable)
            {
                SpriteEnable(true);
                isTriggered = false;
                count = 1;
            }
            else
            {
                SpriteEnable(true);
                isTriggered = false;
                Destroy(this.gameObject, DelayToDestroy);
                count = 0;
            }
            //Debug.Log(count);
        }
    }
}