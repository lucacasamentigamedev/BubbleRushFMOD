using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalEventArgsFactory 
{


    private delegate string EventDebug(GlobalEventArgs message);
    private static Dictionary<EventName, EventDebug> methodDebugString;

    static GlobalEventArgsFactory()
    {
        methodDebugString = new Dictionary<EventName, EventDebug>();
    }

    public static string GetDebugString(EventName eventType, GlobalEventArgs message)
    {
        return methodDebugString[eventType](message);
    }
   
}
