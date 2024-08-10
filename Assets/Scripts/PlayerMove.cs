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
    public static int stageScore = 0;
    public static int level = 0;

    public Camera camera;

    GUIStyle style;

    public AudioClip walkClip;
    public AudioClip fixClip;
    public AudioClip jumpClip;

    // Start is called before the first frame update
    void Start()
    {
        secondsLeft = 60;
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        hp=100;
        stageScore = 0;

        style = new GUIStyle();

        style.fontSize = 20;

        camera = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
        camera.backgroundColor = new Color(0.5294f,0.8078f,0.9216f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(transform.position.y <= -20){
        SceneManager.LoadScene("Defeat");
        }
        if(hp <= 0){
            SceneManager.LoadScene("Defeat");
        }

        if(level % 4 != 0){//verifica se o jogador não está no terraço

        
            bool consertadasTodas = true;
            foreach(var j in GameObject.FindGameObjectsWithTag("Window")){
                if(!j.GetComponent<WindowMove>().consertada){
                    consertadasTodas=false;
                    break;
                }
            }
            if(consertadasTodas){
            SceneManager.LoadScene("Victory");
            }
            }
        
        if(secondsLeft <= 0){

            if(level % 4 != 0){//verifica se o jogador não está no terraço
               SceneManager.LoadScene("Defeat"); 
               }else{

               int p1=0;
               int opponent=0;
               foreach(var j in GameObject.FindGameObjectsWithTag("Window")){
                if(!j.GetComponent<WindowMove>().consertada){
                    opponent++;
                }else{
                    p1++;
                }

                if(p1 > opponent){
                SceneManager.LoadScene("Victory");
                }
            }
                
               }
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

            if(secondsLeft <= 30){
                camera.backgroundColor = new Color(0.0f,0.0f, 0.5451f);
            }

        }
        }

        if(Input.GetKey("left")){
            transform.position -= Vector3.right * speed *  Time.deltaTime;
            SoundFXManager.instance.PlaySoundFXClip(walkClip, transform,   SoundOptionButton.soundVolume);
        }else if(Input.GetKey("right")){
            transform.position +=Vector3.right * speed * Time.deltaTime;
            SoundFXManager.instance.PlaySoundFXClip(walkClip, transform,  SoundOptionButton.soundVolume);
        }if (Input.GetKey("z") && canJump) { //pula
            jumpFrames = 0.0f;

            
            if (rb.velocity.y == 0)
            {
                 rb.AddForce(Vector2.up * maxJumpFrames, ForceMode2D.Impulse);
                 SoundFXManager.instance.PlaySoundFXClip(jumpClip, transform,  SoundOptionButton.soundVolume);
               
                jumpFrames = 0f;
                jumping = true;
                canJump = false;
            }
            
        }fixing = false;
        if(Input.GetKey("x")){
            fixing = true;
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
        if(collision.gameObject.tag == "Ground" ){
        canJump = true;
        
        }
    }

     void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Window"){
        Debug.Log("trigger");

        if(fixing){
        var c = collision.GetComponent<WindowMove>();
        if(c.consertada == false){
            c.consertada = true;
            stageScore++;
            SoundFXManager.instance.PlaySoundFXClip(fixClip, transform,  SoundOptionButton.soundVolume);
            }
        }
        
        }
    }

    

     void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" ){
        canJump = false;
        
        }
    }

    void OnGUI(){
        GUI.Label(new Rect(10,10,100,20),"HP: "+hp.ToString(),style);
        GUI.Label(new Rect(10,30,100,20),"Time left: "+secondsLeft.ToString(),style);
        GUI.Label(new Rect(10,50,100,20),"Score: "+stageScore.ToString(),style);
    }
}
