using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject asteroid;

    [SerializeField]
    Sprite prefebAsteroid1;
    [SerializeField]
    Sprite prefebAsteroid2;
    [SerializeField]
    Sprite prefebAsteroid3;
    /// <summary>
    /// The asteroid script
    /// </summary>
    // Start is called before the first frame update
    Vector3 scaleChange;
    CircleCollider2D collider;

    void Start()
    {

   
    }
    public void Initialize(float angle, Vector3 location) 
    {
        
        transform.position = location;
        SpriteRenderer spriteRender = asteroid.GetComponent<SpriteRenderer>();
        int SpriteNumber = Random.Range(0, 3);
        switch (SpriteNumber)
        {
            case 1:
                spriteRender.sprite = prefebAsteroid1;
                break;
            case 2:
                spriteRender.sprite = prefebAsteroid2;
                break;
            default:
                spriteRender.sprite = prefebAsteroid3;
                break;
        }
        StartMoving(angle);
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Play(AudioClipName.AsteroidHit);
        if (collision.gameObject.tag == "Bullet") 
        {
            Destroy(collision.gameObject);
            if (transform.localScale.x < 0.5)
            {
                Destroy(gameObject);
            }
            else
            {
                collider = GetComponent<CircleCollider2D>();
                scaleChange = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2);
                asteroid.transform.localScale = scaleChange;
                collider.radius /= 2;

                float angle1 = Random.Range(2, 0 * Mathf.PI);
                GameObject mini1 = Instantiate(gameObject);
                mini1.GetComponent<Asteroid>().StartMoving(angle1);
                float angle2 = Random.Range(2, 0 * Mathf.PI);
                GameObject mini2 = Instantiate(gameObject);
                mini2.GetComponent<Asteroid>().StartMoving(angle2);

                Destroy(gameObject);
            }


        }
    }
    public void StartMoving(float angle) 
    {
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle),
        Mathf.Sin(angle));
        const float MinImulseForce = 1f;
        const float MaxImulseForce = 2f;
        float forse = Random.Range(MinImulseForce, MaxImulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * forse, ForceMode2D.Impulse);
    }


}
