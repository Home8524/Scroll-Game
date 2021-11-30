using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BContoller : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;

    private void Awake()
    {
        Prefab = Resources.Load("Prefabs/ElectBall") as GameObject;
    }
    void Start()
    {
        //Destroy(this.transform.gameObject, 2.0f);
        Invoke("DestroyBullet", 2.0f);
    }

    private void DestroyBullet()
    {
        GameObject Obj = Instantiate(Prefab);
        Obj.transform.position = this.transform.position;
        Destroy(this.transform.gameObject);
        Destroy(Obj,1.0f);

    }
}
