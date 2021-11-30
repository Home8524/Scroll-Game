using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActive : MonoBehaviour
{
    public GameObject target;

    public void SetCanvasActive()
    {
        target.SetActive(!target.active);
    }
}
