using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioPlayer : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    public ScoreKeeper sc;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            if(gameObject.tag=="Green"){
                sc.IncreseScore();
            }else{
                sc.decreaseScore();
            }
            
            SoundManager.sndMan.PlaySound(audioClip);
            Destroy(this.gameObject);
        }
    }
}
