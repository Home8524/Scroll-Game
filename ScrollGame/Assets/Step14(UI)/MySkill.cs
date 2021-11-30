using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySkill : MonoBehaviour
{
    private GameObject Player;
    private GameObject Ground;
    [SerializeField] private GameObject BulletPrefab;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        Ground = GameObject.Find("Ground");
    }
    private void Start()
    {
        BulletPrefab = Resources.Load("Prefabs/TestBullet") as GameObject;
    }

    public void GetSkill()
    {
        GameObject Obj = Instantiate(BulletPrefab);

        Obj.transform.position = new Vector3(
            Ground.transform.position.x-Random.Range(-10,10),
            0.0f,
            Ground.transform.position.z - Random.Range(-10, 10)
            );


    }
}
