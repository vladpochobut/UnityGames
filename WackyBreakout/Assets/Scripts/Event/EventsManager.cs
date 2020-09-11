using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventsManager 
{
    public static PickupBlock invoker;
    public static UnityAction<float> listener;

    public static List<PickupBlock> invokersTwo = new List<PickupBlock>();
    //public static UnityAction<float, float> listenerTwo;
    public static List<UnityAction<float, float>> listenersTwo = new List<UnityAction<float, float>>();

    public static void AddInvoker(PickupBlock pickup)
    {
        invoker = pickup;
        if (listener != null)
        {
            invoker.AddFreezerEffectListener(listener);

        }

    }
    public static void AddListener(UnityAction<float> handle)
    {
        listener = handle;
        if (invoker != null)
        {
            invoker.AddFreezerEffectListener(handle);

        }
    }

    public static void AddInvokerTwo(PickupBlock pickupTwo)
    {
        invokersTwo.Add(pickupTwo);
        foreach (UnityAction<float, float> unityAction in listenersTwo)
        {
            pickupTwo.AddSpeedUpEffectListener(unityAction);

        }

    }
    public static void AddListenerTwo(UnityAction<float, float> handleTwo)
    {
        listenersTwo.Add(handleTwo);
        foreach (PickupBlock pickup in invokersTwo)
        {

            pickup.AddSpeedUpEffectListener(handleTwo);

        }
    }

    //public static void AddInvokerTwo(PickupBlock pickupTwo)
    //{
    //    invokersTwo.Add(pickupTwo);
    //    if(listenerTwo != null) 
    //    { 
    //        pickupTwo.AddSpeedUpEffectListener(listenerTwo);
    //    }

    //}
    //public static void AddListenerTwo(UnityAction<float, float> handleTwo)
    //{
    //    listenerTwo = handleTwo;
    //    foreach (PickupBlock pickup in invokersTwo)
    //    {
    //        pickup.AddSpeedUpEffectListener(handleTwo);
    //    }

    //}



}
