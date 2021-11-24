using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    private GameObject Cubeprefab;

    private void Start()
    {
        Cubeprefab = Resources.Load("Prefabs/Step12/Cube") as GameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Button");
            Ray ray = Camera.main.ScreenPointToRay(
                Input.mousePosition);

            RaycastHit Hit;

            if (Physics.Raycast(ray, out Hit, Mathf.Infinity))
            {
                GameObject Obj = Instantiate(Cubeprefab);
                Obj.transform.position = Hit.point;
            }
        }
    }
}
