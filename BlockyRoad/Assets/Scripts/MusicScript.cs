using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private AudioSource audioSource;
    public static MusicScript instance;

    private void Awake()
    {

        if (instance == null)
            instance = this;
        else 
        {
            Destroy(gameObject);        
        }
        
        
        DontDestroyOnLoad(transform.gameObject);
        float voll =  PlayerPrefs.GetFloat("volume");
        
        audioSource = GetComponent<AudioSource>();
        if (voll != null)
        {
            audioSource.volume = voll;
        }
        if (!audioSource.isPlaying)
        {     
            PlayMusic();
        }
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void setVolume(float vol)
    {
        audioSource.volume = vol;
        PlayerPrefs.SetFloat("volume", vol);
    }

    public float GetVolume()
    {
        return audioSource.volume;
    
    } 
}
