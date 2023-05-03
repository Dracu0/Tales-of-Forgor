using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource soundToTriggerSource;
    [SerializeField] private float SFXTriggerVolume;
    public AudioClip soundToTrigger;
    private bool isTriggered;
    int count = 1;
    
    private void Start()
    {
        SFXTriggerVolume = 0.5f;
        soundToTriggerSource = this.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isTriggered = true;

            if (isTriggered && count == 1)
            {
                soundToTriggerSource.PlayOneShot(soundToTrigger, SFXTriggerVolume);
                count -= 1;
            }
        }
        Debug.Log(isTriggered);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isTriggered = false;
            Destroy(this.gameObject, soundToTrigger.length);
            count = 0;
        }
        Debug.Log("Exited");
        Debug.Log(count);
    }

}