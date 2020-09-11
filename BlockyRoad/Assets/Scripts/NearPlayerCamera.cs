using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearPlayerCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
        offset = transform.position - Player.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Player != null)
        transform.position = new Vector3(Player.transform.position.x,2f,Player.transform.position.z) + offset;
       
    }
}
