using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //**키입력 움직임
    [SerializeField] private float Speed = 0.0f;
    [SerializeField] private GameObject BulletParent = null;
    [SerializeField] private GameObject BulletPrefab;
    private void Awake()
    {
        BulletParent = new GameObject("BulletList");
        BulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        
    }
    private int Count;
    private void Start()
    {
        Speed = 10.0f;
        Count = 0;
        Rigidbody BulletRigid = BulletPrefab.GetComponent<Rigidbody>();
        BulletRigid.useGravity = false;

        SphereCollider BulletColider = BulletPrefab.GetComponent<SphereCollider>();
        BulletColider.isTrigger = false;

    }

    // Update is called once per frame
    private void Update()
    {
        //** Min -1   Max 1을 반환
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        this.transform.Translate(
            Hor * Speed * Time.deltaTime,
            0.0f,
            Ver * Speed * Time.deltaTime
            );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(ObjectManager.Getinstance().GetDisableList.Count==0)
            {
                for(int i=0;i<5;++i)
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

    }
   
}
