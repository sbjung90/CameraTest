using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AI;

public class StateSingleton<T>  where T : new()
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }
}
