using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D rb;
    public BoxCollider2D bc;

    private bool canJump=true;
    private bool jumping=false;
    public bool fixing = false;

    public float speed = 1f;
    public int jumpHeight = 15;
    float jumpFrames = 0f;
    int maxJumpFrames = 15;

    int secondsLeft;
    private float timer = 0.0f;
    private float scrollBar = 1.0f;

    public static int hp = 100;
    public static int score=0;

    // Start is called before the first frame update
    void Start()
    {
        secondsLeft = 60;
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        hp=100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
        if(hp <= 0){
            
        }

        if(secondsLeft <= 0){

        }else{
           timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > 1)
        {
            secondsLeft--;

            // Remove the recorded 2 seconds.
            timer = timer - 1;
            Time.timeScale = scrollBar;
        }
        }

        if(Input.GetKey("left")){
            transform.position -= Vector3.right * speed *  Time.deltaTime;
        }else if(Input.GetKey("right")){
            transform.position +=Vector3.right * speed * Time.deltaTime;
        }if (Input.GetKey("z") && canJump) { //pula
            jumpFrames = 0.0f;

            
            if (rb.velocity.y == 0)
            {
                 rb.AddForce(Vector2.up * maxJumpFrames, ForceMode2D.Impulse);

               
                jumpFrames = 0f;
                jumping = true;
                canJump = false;
            }
            
        }if(Input.GetKey("x")){
            fixing = true;
        }else{
            fixing = false;
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
        if(collision.gameObject.tag == "Ground"){
        canJump = true;
        
        }
    }

     void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Window"){
        Debug.Log("trigger");
        if(fixing){
            collision.GetComponent<WindowMove>().consertada = fixing;
        }
        
        }
    }

     void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground"){
        canJump = false;
        
        }
    }

    void OnGUI(){
        GUI.Label(new Rect(10,10,100,20),"HP: "+hp.ToString());
        GUI.Label(new Rect(10,30,100,20),"Time left: "+secondsLeft.ToString());
    }
}
