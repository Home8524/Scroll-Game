using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraTest : MonoBehaviour
{
    /*
      
     
    private Camera mainCamera;
    private GameObject Obj;

    private void Start()
    {

        Obj = GameObject.Find("Cube");

        mainCamera = Camera.main;

        mainCamera.orthographic = true;
        mainCamera.orthographicSize = 6.0f;

        mainCamera.rect = new Rect(0.0f, 0.0f, 16.0f, 9.0f);
    
    }

    private void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        Obj.transform.position = new Vector3(
          (mainCamera.rect.width/mainCamera.rect.height) *
          mainCamera.orthographicSize * Hor,
            mainCamera.orthographicSize * Ver,
            0.0f
            );


        if(Hor !=0)
        {
            if(Hor > 0)
            {
                Obj.transform.position = new Vector3
                    (   
                        mainCamera.orthographicSize,
                        0.0f,
                        0.0f
                     );
            }
            else
            {
                Obj.transform.position = new Vector3
                    (
                        -mainCamera.orthographicSize,
                        0.0f,
                        0.0f
                     );
            }
        }

        if (Ver != 0)
        {
            if (Ver > 0)
            {
                Obj.transform.position = new Vector3
                    (0.0f,
                    mainCamera.orthographicSize,
                    0.0f);

            }
            else
            {
                Obj.transform.position = new Vector3
                    (0.0f,
                    -mainCamera.orthographicSize,
                    0.0f);
            }
        }
        */
    private void Update()
    {
        
    
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Step15");
        }


        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Step14");
        }


    }
}
