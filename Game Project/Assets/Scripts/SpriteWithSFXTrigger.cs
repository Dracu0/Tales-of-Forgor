using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteWithSFXTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource soundToTriggerSource;
    [SerializeField] private float SFXTriggerVolume;
    [SerializeField] private SpriteRenderer SpriteOnTrigger;
    [SerializeField] private float DelayBetweenClips;
    [SerializeField] private float DelayToDestroy;
    [SerializeField] private bool destroyOnDelay;
    public AudioClip[] soundToTrigger;
    private bool isTriggered;
    int count = 1;

    private void Start()
    {
        SFXTriggerVolume = 0.5f;
        SpriteOnTrigger = this.GetComponent<SpriteRenderer>();
        SpriteOnTrigger.enabled = false;
    }

    private void Update()
    {
        if (isTriggered == true && destroyOnDelay == true)
        {
            Destroy(this.gameObject, DelayToDestroy);
            count = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isTriggered = true;

            if (isTriggered && count == 1)
            {
                SpriteOnTrigger.enabled = true;
                StartCoroutine(PlayMultiple());
                count -= 1;
            }
        }
        //Debug.Log(isTriggered);
    }

    IEnumerator PlayMultiple()
    {
        soundToTriggerSource.PlayOneShot(soundToTrigger[0], SFXTriggerVolume);
        yield return new WaitForSeconds(DelayBetweenClips);
        soundToTriggerSource.PlayOneShot(soundToTrigger[1], SFXTriggerVolume);
        yield return new WaitForSeconds(DelayBetweenClips);
        soundToTriggerSource.PlayOneShot(soundToTrigger[2], SFXTriggerVolume);
    }

    private void DestroyOnDelay()
    { 
        if (tag == "Player")
        {
            isTriggered = true;
            Destroy(this.gameObject, DelayToDestroy);
            count = 0;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isTriggered = false;
            Destroy(this.gameObject, soundToTrigger[2].length);
            count = 0;
        }
        //Debug.Log("Exited");
        //Debug.Log(count);
    }

}
