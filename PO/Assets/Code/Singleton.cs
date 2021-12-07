using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton 
{
    static private Singleton Instance;
    static public Singleton GetInstance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new Singleton();
            }
            return Instance;
        }
    }

    // 0 : Ball1 , 1 : Ball2
    public int BallSet = 0;
    public Vector2 PosSave = new Vector2();
    public int TimeNum = 1;
}
