﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoumeValueChange : MonoBehaviour
{
    private AudioSource audioSource;

    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;

    }

    public void SetVolume(float vol)
    {
        vol = PlayerPrefs.GetFloat("volume");
        musicVolume = vol;

    }
}
