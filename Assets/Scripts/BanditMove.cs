using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public GameObject player;
    public float speed = 2f;
    public bool canJump = true;
    public bool jumping = false;

    public int jumpHeight = 15;
    float jumpFrames = 0f;
    int maxJumpFrames = 15;
    private bool atacando = false;
    private int framesAtacando = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        atacando = false;
        framesAtacando=0;
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

        float delta = Vector3.Distance(transform.position,player.transform.position);
        if(delta <= 10f){
            if(transform.position.x < player.transform.position.x){
                 transform.position += Vector3.right * speed *  Time.deltaTime;
            }else if(transform.position.x > player.transform.position.x){
                 transform.position -= Vector3.right * speed *  Time.deltaTime;
            }if(transform.position.y < player.transform.position.y && canJump){
                

                if (rb.velocity.y == 0)
            {
                 rb.AddForce(Vector2.up * maxJumpFrames, ForceMode2D.Impulse);

               
                jumpFrames = 0f;
                jumping = true;
                canJump = false;
            }
            }
        }

        if (jumping) {
            jumpFrames += Time.deltaTime;

            if (jumpFrames >= maxJumpFrames) {
                jumping = false;
                jumpFrames = 0.0f;
            }
            
        }
        else
        {
            jumpFrames = 0.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
        //if(Random.Range(0,101) > 50){

            atacando = true;
            framesAtacando=0;
            //PlayerMove.hp -= 1;
            //}
        }if(collision.gameObject.tag == "Ground"){
        canJump = true;
        
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
            }
        //}
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Window"){
        Debug.Log("trigger");
        if(Random.Range(0,101) > 80){
        
            collision.GetComponent<WindowMove>().consertada = false;
        }
        
        }
    }

     void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground"){
        canJump = false;
        
        }if(collision.gameObject.tag == "Player"){
        atacando = false;
        framesAtacando=0;
        }
    }}
}
