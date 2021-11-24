using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonParent<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T Instance = null;

    public static T GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new GameObject(typeof(T).ToString(), typeof(T)).AddComponent<T>();
            return Instance;
        }
    }
     public virtual void Initialize()
    {
        Debug.Log("SingleTonParent");
    }
}
