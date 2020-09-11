using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    [SerializeField]
    Sprite freezBlock;

    [SerializeField]
    Sprite speedUpBlock;

    public PickupEffect pickupEffect;
    public float freezerEffectDuration;
    public float speedUpDuration;
    public float speedUpForse;
    public FreezerEffectActivated freezerEffectActivated;
    public SpeedUpEffectActivated speedUpEffectActivated;
    // Start is called before the first frame update
    void Start()
    {
        freezerEffectActivated = new FreezerEffectActivated();
        freezerEffectDuration = ConfigurationUtils.FreezerDurationSeconds;

        speedUpEffectActivated = new SpeedUpEffectActivated();
        speedUpDuration = 6;
        speedUpForse = 20;
      
        bonusCoins = ConfigurationUtils.PointsForPickupBlock;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        switch (pickupEffect) 
        {
            case PickupEffect.Freezer :
                spriteRenderer.sprite = freezBlock;
                EventsManager.AddInvoker(this);
                break;
            case PickupEffect.Speedup :
                spriteRenderer.sprite = speedUpBlock;
                EventsManager.AddInvokerTwo(this);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivated.AddListener(listener);
    }

    public void AddSpeedUpEffectListener(UnityAction<float, float> listener)
    {
        speedUpEffectActivated.AddListener(listener);
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (pickupEffect == PickupEffect.Freezer)
        {
            freezerEffectActivated.Invoke(freezerEffectDuration);
     
        }
        if (pickupEffect == PickupEffect.Speedup)
        {
            speedUpEffectActivated.Invoke(speedUpDuration, speedUpForse);
      
        }
        Destroy(gameObject);
    }


}
