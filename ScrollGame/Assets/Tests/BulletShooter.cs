using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private GameObject BulletParent = null;
    [SerializeField] private GameObject BulletPrefab;

    private void Awake()
    {
        BulletParent = new GameObject("BulletList");
        BulletPrefab = Resources.Load("Prefabs/Bullet1") as GameObject;
    }
    private int Count;
    void Start()
    {
        Count = 0;
        Rigidbody BulletRigid = BulletPrefab.GetComponent<Rigidbody>();
        BulletRigid.useGravity = false;

        SphereCollider BulletColider = BulletPrefab.GetComponent<SphereCollider>();
        BulletColider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (ObjectManager.Getinstance().GetDisableList.Count == 0)
            {
                for (int i = 0; i < 5; ++i)
                {
                    GameObject obj = Instantiate(BulletPrefab);
                    obj.SetActive(false);
                    obj.transform.name = Count.ToString();
                    Count++;
                    ObjectManager.Getinstance().GetDisableList.Push(obj);
                }
            }
            GameObject Bullet = ObjectManager.Getinstance().GetDisableList.Pop();

            Bullet.SetActive(true);
            Bullet.transform.position = transform.position;
            Bullet.transform.rotation = transform.rotation;
            Bullet.transform.parent = BulletParent.transform;

            ObjectManager.Getinstance().GetEnableList.Add(Bullet);
        }
    }
}
