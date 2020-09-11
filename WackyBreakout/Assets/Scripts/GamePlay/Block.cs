using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    protected int bonusCoins = 5;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<HUD>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball") 
        {
            HUD.AddScore(bonusCoins);
            Destroy(gameObject);
        
        }
    }
}
