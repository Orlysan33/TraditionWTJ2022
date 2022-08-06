using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    [SerializeField]
    private AudioSource footStepAudioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFootStepSound(bool play)
    {
        if(play)
        {            
            if (!footStepAudioSource.isPlaying)
            {
                footStepAudioSource.Play();
            }
        }
        else
        {
            footStepAudioSource.Stop();
        }
    }
}
