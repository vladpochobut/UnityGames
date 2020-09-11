using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    public SpeedUpEffectActivated speedUpEffectActivated;
    Timer effectTimer;
   static bool isItActive;
    static float speed;
    static  float remainingTime;

   

    void Start()
    {
        isItActive = false;
       EventsManager.AddListenerTwo(InfoAboutSpeedUpEffect);
         effectTimer = gameObject.AddComponent<Timer>();
    }

    private void Update()
    {
        if (isItActive == true)
        {
            remainingTime = effectTimer.remainingTime;  
            
        }
    }
    void InfoAboutSpeedUpEffect(float effectDuraton , float speedForce )
    {
        effectTimer.Duration = effectDuraton;
        effectTimer.Run();
        speed = speedForce;
        isItActive = true;
        remainingTime = effectTimer.remainingTime;
    }
    public bool IsItActive
    {
        get { return isItActive; }
    }

    public float Speed
    {
        get { return speed; }
    }

    public float RemainingTime
    {
        get { return remainingTime; }
    }
}
