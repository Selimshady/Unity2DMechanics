using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource audioSource;

    
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void playClip(AudioClip clip)
    {
        randomizeSOund();
        audioSource.PlayOneShot(clip);
    }

    private void randomizeSOund()
    {
        audioSource.pitch = Random.Range(.75f,1.5f);
        audioSource.volume = Random.Range(.75f,1.5f);
    }
}
