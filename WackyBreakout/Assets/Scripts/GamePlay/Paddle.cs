using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    /// <summary>
    /// paddle
    /// </summary>
    // Start is called before the first frame update
    [SerializeField]
    Sprite prefabFrozen;
    [SerializeField]
    Sprite prefabCommon;

    Rigidbody2D rb;
    BoxCollider2D bc;
    float halfOfColliderWidth;
    float halfOfColliderHeight;
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;
    Vector2 hitPoint;
    bool IsItFreezed = false;
    Timer freezTimer;
    SpriteRenderer spriteRenderer;
    void Start()
    {

        freezTimer = gameObject.AddComponent<Timer>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        halfOfColliderWidth = bc.size.x / 2;
        halfOfColliderHeight = bc.size.y / 2;
        EventsManager.AddListener(HandleFreezeEffectActivated);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
      
        if (freezTimer.Finished)
        {
            spriteRenderer.sprite = prefabCommon;
            freezTimer.Stop();
            IsItFreezed = false;
        }
        if (IsItFreezed == false)
        {
            
            float horizontal = Input.GetAxis("Horizontal");
            if (horizontal != 0)
            {


                Vector2 velocity = new Vector2(horizontal, 0);
                CalculateClampedX();
                rb.MovePosition(rb.position + velocity * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime);

            }
        }
    }
    public float CalculateClampedX()
    {
        Vector2 posistion = transform.position;
        if (posistion.x + halfOfColliderWidth > ScreenUtils.ScreenRight)
        {
            posistion.x = ScreenUtils.ScreenRight - halfOfColliderWidth;
            transform.position = posistion;
            return posistion.x;
        }
        else
        {
            if (posistion.x - halfOfColliderWidth < ScreenUtils.ScreenLeft)
            {
                posistion.x = ScreenUtils.ScreenLeft + halfOfColliderWidth;
                transform.position = posistion;
                return posistion.x;
            }

        }
        return posistion.x;

    }
    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll )
    {
      
            if (coll.gameObject.CompareTag("Ball") && IsItTop(coll))
            {
                // calculate new ball direction
                float ballOffsetFromPaddleCenter = transform.position.x -
                    coll.transform.position.x;
                float normalizedBallOffset = ballOffsetFromPaddleCenter /
                    halfOfColliderWidth;
                float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
                float angle = Mathf.PI / 2 + angleOffset;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                // tell ball to set direction to new direction
                Ball ballScript = coll.gameObject.GetComponent<Ball>();
                ballScript.SetDirection(direction);
            }
        
    }

    public bool IsItTop(Collision2D coll)
    {
      
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D[] contacts = coll.contacts;
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }

    void HandleFreezeEffectActivated(float duration)
    {
        freezTimer.Duration = duration;
        freezTimer.Run();
        if (freezTimer.Running)
        {
            IsItFreezed = true;
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = prefabFrozen;
        }

    }

}
