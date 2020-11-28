using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float transiton = Input.GetAxis("Horizontal") * 10f * Time.deltaTime;

        transform.Translate(transiton, 0 , 0);
      
    }
}
