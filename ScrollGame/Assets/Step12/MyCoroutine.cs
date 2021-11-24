using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCoroutine : MonoBehaviour
{
    public float fTIme=0;

    private void Start()
    {
        StartCoroutine("Test");
    }

    IEnumerator Test()
    {
            yield return new WaitForSeconds(fTIme);

        Destroy(gameObject);
    }
}
