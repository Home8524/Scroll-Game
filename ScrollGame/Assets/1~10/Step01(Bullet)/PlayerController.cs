using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*물리엔진 사용 움직임
    public Rigidbody Rigid;

    void Start()
    {
        Rigid.AddForce(Vector3.forward*2000);
    }
    [SerializeField] private Rigidbody Rigid;
   
    private void Awake()
    {
        Rigid = GameObject.Find("Player").GetComponent<Rigidbody>();
        //GameObject Player = GameObject.Find("Player");
        //Rigid =  Player.gameObject.GetComponent<Rigidbody>();
    }
    */

    //**키입력 움직임
    [SerializeField] private float Speed = 0.0f;
    [SerializeField] private GameObject Bulletobj;

    private List<GameObject> BulletList=new List<GameObject>();
    private GameObject BulletParent=null;
    private int BulletCnt = 0;

    private void Start()
    {
        BulletCnt = 0;
    }
    private void Awake()
    {
        BulletParent = new GameObject("BulletList");
    }
    private void Update()
    {
        //** Min -1   Max 1을 반환
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");
        
        this.transform.Translate(
            Hor * Speed*Time.deltaTime,
            0.0f,
            Ver * Speed * Time.deltaTime
            );
         
        //if(Hor==1.0f)
        //   this.transform.Rotate(Vector3.up, 0.5f);
        //else if(Hor==-1.0f)
        //   this.transform.Rotate(Vector3.up,-0.5f);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Bullet = Instantiate(Bulletobj);
            Bullet.transform.position = transform.position;

            Bullet.GetComponent<Rigidbody>().useGravity = false;

            Bullet.transform.parent = BulletParent.transform;
            Bullet.transform.name = BulletCnt.ToString();
            BulletCnt++;
            BulletList.Add(Bullet);

        }

    }
}
