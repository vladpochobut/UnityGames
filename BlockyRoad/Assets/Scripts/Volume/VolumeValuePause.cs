using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValuePause : MonoBehaviour
{

    public void SetVolume(float vol)
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicScript>().setVolume(vol);
    }
}
