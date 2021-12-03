using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSingleton 
{
    static private DinoSingleton Instance;
    static public DinoSingleton GetInstance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new DinoSingleton();
            }
            return Instance;
        }
    }

    public bool Hit =false;
}
