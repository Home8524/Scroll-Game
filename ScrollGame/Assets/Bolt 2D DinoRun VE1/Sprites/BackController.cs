using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackController : MonoBehaviour
{
    Vector3 mainCameraSpeed;
    Animator Anim;
   [SerializeField] private bool Hit;
    private bool Jump;
    GameObject Test;
    GameObject Canvas;

    private Text ScoreNumber;
    private int Score;

    private void Start()
    {
        ScoreNumber = GameObject.Find("ScoreNumber").GetComponent<Text>();
        Score = 0;

        Jump = false;
        Test = GameObject.Find("UI Over");
        Canvas = GameObject.Find("Button");
        Test.SetActive(false);
        Canvas.SetActive(false);
        Hit = false;
        Anim = transform.GetComponent<Animator>();
        mainCameraSpeed = Vector3.right * 10.0f;
       
    }
    void Update()
    {
        Hit = DinoSingleton.GetInstance.Hit;
        if(!Hit)
        {
            ScoreNumber.text = "Score : " + Score.ToString();
            Score++;
            transform.position += mainCameraSpeed*Time.deltaTime;
        }
        
        if(Input.GetKeyUp(KeyCode.Space)&&!Hit&&!Jump)
            {
                Jump = true;
                Rigidbody2D Rigid = transform.GetComponent<Rigidbody2D>();
                Rigid.AddForce(Vector3.up* 400.0f);
                transform.Rotate(Vector3.zero);
                Anim.SetBool("Jump", true);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Jump = false;

        Anim.SetBool("Jump", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Wall")
        {
            ScoreNumber.text = "Score : " + Score.ToString();
            Score = 0;
            Rigidbody2D Rigid = transform.GetComponent<Rigidbody2D>();
            Rigid.velocity = Vector2.zero;
            Anim.SetBool("Hit", true);
            DinoSingleton.GetInstance.Hit = true;
            Canvas.SetActive(true);
            Test.SetActive(true);
            Vector3 Tmp = transform.position;
            Tmp.x += 6;
            Tmp.y += 3;
            Test.transform.position = Tmp;
        }
    }
}
