using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    //*Singleton
    /*
        private static Singleton Instance = null;
        public static Singleton Getinstance()
        {
            if (Instance == null)
                Instance = new Singleton();
            return Instance;
        }
    */

    //*Singleton2
    /*
        private static Singleton Instance = null;
        public static Singleton Getinstance
        {
            get
            {
                if (Instance == null)
                    Instance = new Singleton();
                return Instance;
            }
        }
     */

    //Singleton 3
    private static Singleton Instance = null;
    private static GameObject Container = null;
    public static Singleton Getinstance()
    {
        
        if (Instance == null)
         { 
             Container = new GameObject("Singleton");
             Instance = new Singleton();

             Instance = Container.AddComponent(typeof(Singleton)) as Singleton;
         }

            return Instance;
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
            Debug.Log("Singleton");
    }
    public void Output()
    {
        Debug.Log("Singleton");
    }
}
