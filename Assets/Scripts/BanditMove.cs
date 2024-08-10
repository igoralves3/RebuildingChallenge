using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
        if(Random.Range(0,101) > 50){

        
            PlayerMove.hp -= 1;
            }
        }
    }

     void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
