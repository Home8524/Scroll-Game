using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager 
{

    private static ObjectManager Instance = null;
    public static ObjectManager Getinstance()
    {
        if (Instance == null)
            Instance = new ObjectManager();
        return Instance;
    }

    //Bullet을 관리하는 List
    private List<GameObject> EnableList = new List<GameObject>();
    public List<GameObject> GetEnableList
    {
        get
        {
            return EnableList;
        }
    }
    private Stack<GameObject> DisableList = new Stack<GameObject>();

    public Stack<GameObject> GetDisableList
    {
        get
        {
            return DisableList;
        }
    }
     
}
