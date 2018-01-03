using UnityEngine;
using System.Collections;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance;
    public static T GetInstance()
    {
        if (instance == null) instance = FindObjectOfType(typeof(T)) as T;
        return instance;
    }
}
