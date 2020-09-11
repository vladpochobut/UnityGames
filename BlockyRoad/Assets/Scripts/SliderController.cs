using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField]
    private Slider thisSlider;
    // Start is called before the first frame update
    void Start()
    {
       float volume = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicScript>().GetVolume();
        thisSlider.value = volume;
    }

  
}
