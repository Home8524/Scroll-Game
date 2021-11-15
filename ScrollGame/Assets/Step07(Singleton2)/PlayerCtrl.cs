using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float pSpeed;
    public Rigidbody Rigid;
    [SerializeField] private GameObject BulletParent = null;
    [SerializeField] private GameObject BulletPrefab;
    private int Count;
    private int Stay = 0;
    private void Awake()
    {
        Rigid = GameObject.Find("Player").GetComponent<Rigidbody>();
        BulletParent = new GameObject("BulletList");
        BulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;

    }

    void Start()
    {
        Count = 0;
        Rigidbody BulletRigid = BulletPrefab.GetComponent<Rigidbody>();
        BulletRigid.useGravity = false;

        SphereCollider BulletColider = BulletPrefab.GetComponent<SphereCollider>();
        BulletColider.isTrigger = false;

        pSpeed = SampleObjectManager.GetInstance.Speed*-1;    
    }

    private void Update()
    {
        //** Min -1   Max 1À» ¹ÝÈ¯
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        this.transform.Translate(
            Hor * pSpeed * Time.deltaTime,
            0.0f,
            Ver * pSpeed * Time.deltaTime
            );

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
            Bullet.transform.parent = BulletParent.transform;

            ObjectManager.Getinstance().GetEnableList.Add(Bullet);
        }

        
       if (Input.GetKeyDown(KeyCode.V)&&Stay==0)
        {
            Rigid.AddForce(Vector3.up*300.0f);
            Rigid.useGravity = true;
            Stay = 1;
        }

    }
        private void OnCollisionEnter(Collision collision)
        {
            Rigid.useGravity = false;
            Stay = 0;
        }

}
