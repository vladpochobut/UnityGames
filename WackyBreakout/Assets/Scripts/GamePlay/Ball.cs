using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Sprite prefabSpeedBall;

    [SerializeField]
    Sprite commonBall;

    Rigidbody2D rb;
    Timer deathTimer;
    Timer waithingTimer;
    Timer speedUpTimer;
    bool isItSpeedUp = false;
    SpriteRenderer spriteRenderer;


    //

    float remT = EffectUtils.RemainingTime;
    bool isit = EffectUtils.IsItActive;
    float sped = EffectUtils.Speed;

    //
    /// <summary>
    /// Ball
    /// </summary>
    // Start is called before the first frame update


    void Start()
    {
       
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeTimeSeconds;
        deathTimer.Run();

        waithingTimer = gameObject.AddComponent<Timer>();
        waithingTimer.Duration = 1;
        waithingTimer.Run();

        speedUpTimer = gameObject.AddComponent<Timer>();
        EventsManager.AddListenerTwo(HandleSpeedUpEffectActivated);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

       
    }

    // Update is called once per frame
    void Update()
    {

        if (waithingTimer.Finished) 
        {

            AddForse();
            waithingTimer.Stop();
            if (isit == true)
            {
                //TODO:
                print("DIDI");
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, sped);
                speedUpTimer.Duration = remT;
            }
        }
        if (deathTimer.Finished) 
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }
        if (speedUpTimer.Finished)
        {
            spriteRenderer.sprite = commonBall;
            speedUpTimer.Stop();
            isItSpeedUp = false;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 2.4f);

        }
     
    }
    public void SetDirection(Vector2 direction) 
    {
        rb.velocity = direction * rb.velocity.magnitude;

    }
    public void AddForse() 
    {
       

        rb = GetComponent<Rigidbody2D>();

        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1) * ConfigurationUtils.BallImpulseForse, ForceMode2D.Force);

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

       

    }
    private void OnBecameInvisible()
    {
        if (transform.position.y < ScreenUtils.ScreenBottom || transform.position.x < ScreenUtils.ScreenLeft)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            HUD.MinusBall();
            Destroy(gameObject);
        }

    }
    void HandleSpeedUpEffectActivated(float duration, float forse)
    {

        speedUpTimer.Duration = duration;
        speedUpTimer.Run();
        rb = GetComponent<Rigidbody2D>();
        if (speedUpTimer.Running)
        {
            if (rb.velocity.magnitude > 3)
            {
            
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, forse);
               
                
            }
            else
            {
                rb.AddForce(rb.velocity * forse, ForceMode2D.Force);
                isItSpeedUp = true;
              
            }
        }
    }
}
