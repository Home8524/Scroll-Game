using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float CameraSpeed;
    public Camera mainCamera;
    Animator Anim;
    private GameObject Container = null;

    private GameObject StonePrefab;
    private GameObject CloudPrefabA;
    private GameObject CloudPrefabB;
    private GameObject CactusPrefabs1;
    private GameObject CactusPrefabs2;
    private GameObject CactusPrefabs3;
    private GameObject Obj4;
    private void Awake()
    {
        StonePrefab = Resources.Load("Prefabs/DinoRun/Back A") as GameObject;
        CloudPrefabA = Resources.Load("Prefabs/DinoRun/Cloud A") as GameObject;
        CloudPrefabB = Resources.Load("Prefabs/DinoRun/Cloud B") as GameObject;
        CactusPrefabs1 = Resources.Load("Prefabs/DinoRun/Cactus A") as GameObject;
        CactusPrefabs2 = Resources.Load("Prefabs/DinoRun/Cactus B") as GameObject;
        CactusPrefabs3 = Resources.Load("Prefabs/DinoRun/Cactus C") as GameObject;
    }
    private void Start()
    {
        GameObject Player = GameObject.Find("Player");

        Anim = Player.transform.GetComponent<Animator>();

        Container = new GameObject("Tester");
        for (int i=1;i<16;++i)
        {
            float Tmp = (i + 1) * 20.0f;
            
            int Select = Random.Range(0, 4);
           
            switch (Select)
            {
                case 0:
                    Obj4 = Instantiate(CactusPrefabs1);
                    break;
                case 1:
                    Obj4 = Instantiate(CactusPrefabs2);
                    break;
                case 2:
                    Obj4 = Instantiate(CactusPrefabs3);
                    break;
                default:
                    Obj4 = Instantiate(StonePrefab);
                    break;

            }

            Obj4.transform.position = new Vector3(
                Random.Range(Tmp - 20.0f, Tmp),
                -0.05f,
                -0.5f
                );
            if (i == 3)
                Obj4.name = "Stone " + i;
            else
                Obj4.name = "Cactus " + i;
            Obj4.transform.parent = Container.transform;

            //2~6
            GameObject Obj2 = Instantiate(CloudPrefabA);
            Obj2.transform.position = new Vector3(
                Random.Range(Tmp - 20.0f, Tmp),
                Random.Range(2.0f,6.0f),
                -0.5f
                );
            Obj2.name = "CloudA " + i;
            Obj2.transform.parent = Container.transform;

            GameObject Obj3 = Instantiate(CloudPrefabB);
            Obj3.transform.position = new Vector3(
                Random.Range(Tmp - 20.0f, Tmp),
                Random.Range(2.0f, 6.0f),
                -0.5f
                );
            Obj3.name = "CloudB " + i;
            Obj3.transform.parent = Container.transform;


        }
        CameraSpeed = 10.0f;
    }
    private void Update()
    {

        if (!DinoSingleton.GetInstance.Hit)
            mainCamera.transform.position += Vector3.right * CameraSpeed*Time.deltaTime;    
    }
}
