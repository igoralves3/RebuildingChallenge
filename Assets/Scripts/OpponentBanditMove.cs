using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentBanditMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    public GameObject player;
    public float speed = 2f;

    private bool atacando = false;
    private int framesAtacando = 0;
    private GameObject limiter1,limiter2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        speed = 3f;
        player = GameObject.FindGameObjectWithTag("Player");
        atacando = false;
        framesAtacando=0;
        limiter1 = GameObject.FindGameObjectWithTag("LimiterLeft");
        limiter2 = GameObject.FindGameObjectWithTag("LimiterRight");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    if(transform.position.y <= -20){
            var janelas = GameObject.FindGameObjectsWithTag("Window");
            var r = Random.Range(0,janelas.Length);
            if(janelas[r].GetComponent<WindowMove>().consertada){
                janelas[r].GetComponent<WindowMove>().consertada = false;
                transform.position = janelas[r].transform.position;
            }
        }

    if(speed > 0){
        if(transform.position.x > player.transform.position.x){
            if(Random.Range(0,11) >= 5){
                speed = -speed;
            }
        }
    }else{
    if(transform.position.x < player.transform.position.x){
            if(Random.Range(0,11) >= 5){
                speed = -speed;
            }
        }
    }
         transform.position += Vector3.right * speed *  Time.deltaTime;
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
        //if(Random.Range(0,101) > 50){

            atacando = true;
            framesAtacando=0;
            //PlayerMove.hp -= 1;
            }
        //}
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
    if(collision.gameObject.tag == "LimiterLeft" || collision.gameObject.tag == "LimiterRight"){
        speed = -speed;
    }
        if(collision.gameObject.tag == "Window"){
        Debug.Log("trigger");
        if(Random.Range(0,101) > 50){
        
            collision.GetComponent<WindowMove>().consertada = false;
        }
        
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
        //if(Random.Range(0,101) > 50){

            if(atacando){
            framesAtacando++;
            if(framesAtacando >= 10){
            PlayerMove.hp -= 1;
            framesAtacando=0;
            }
            }}
        //}
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground"){
        
        
        }if(collision.gameObject.tag == "Player"){
        atacando = false;
        framesAtacando=0;
        }
    }


}
