using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleObjectManager :SingletonParent<SampleObjectManager>
{
    public string Name = "SampleObjectManager";
    public float Speed = 10.0f;

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
