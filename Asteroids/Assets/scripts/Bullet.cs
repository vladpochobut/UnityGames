using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    const float BulletLifeSeconds = 2;
    Timer deathTimer;
    // Start is called before the first frame update
    void Start()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = BulletLifeSeconds;
        deathTimer.Run();

    }
    private void Update()
    {
        if (deathTimer.Finished)
        {
            deathTimer.Run();
            Destroy(gameObject);

        }

    }
    /// <summary>
    /// forse bullet in direction in wich player go
    /// </summary>
    /// <param name="direction"></param>
    public void ApllyForse(Vector2 direction) 
    {
        const float forsePower = 6f;
        GetComponent<Rigidbody2D>().AddForce(forsePower * direction, ForceMode2D.Impulse);
        
    }
}
