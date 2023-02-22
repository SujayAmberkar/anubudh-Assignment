using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sndMan;
    private AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        sndMan = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound){
        audioSource.PlayOneShot(sound);
    }
}
