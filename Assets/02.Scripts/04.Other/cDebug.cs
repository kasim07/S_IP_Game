using UnityEngine;
using System.Collections;

static public class CDebug
{
    static public void Log(object message)
    {
        Debug.Log(message);
    }

    static public void Log(object message, Object context)
    {
        Debug.Log(message, context);
    }
}
