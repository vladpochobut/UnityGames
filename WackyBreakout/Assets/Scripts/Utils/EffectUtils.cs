using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    static SpeedupEffectMonitor speedupEffectMonitor = new SpeedupEffectMonitor();

    public static bool IsItActive
    {
        get { return speedupEffectMonitor.IsItActive; }
    }

    public static float Speed
    {
        get { return speedupEffectMonitor.Speed; }
    }

    public static float RemainingTime
    {
        get { return speedupEffectMonitor.RemainingTime; }
    }

    public static void Initialize()
    {
        speedupEffectMonitor = new SpeedupEffectMonitor();
    }

}
