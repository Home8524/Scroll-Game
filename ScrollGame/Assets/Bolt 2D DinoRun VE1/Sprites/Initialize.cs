using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Initialize : MonoBehaviour
{
    public GameObject Player;
    public Camera mainCamera;

    private Text ScoreNumber;
    private void Start()
    {
        ScoreNumber = GameObject.Find("ScoreNumber").GetComponent<Text>();
    }
    public void Initialized()
    {
        DinoSingleton.GetInstance.Hit = false;
        ScoreNumber.text = "Score : 0";
        Player.transform.position = new Vector3(2.0f, 0.0f, -1.0f);
        mainCamera.transform.position = new Vector3(7.6f, 0.69f, -10.0f);
        GameObject Canvas;
        Canvas = GameObject.Find("Button");
        Canvas.SetActive(false);
        GameObject Test;
        Test = GameObject.Find("UI Over");
        Test.SetActive(false);
        
        Animator Anim = Player.transform.GetComponent<Animator>();
        Anim.SetBool("Hit", false);
    }
}
