using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMove : MonoBehaviour
{
    public bool consertada = false;

    public BoxCollider2D bc;
    public SpriteRenderer sr;

    public Sprite janelaQuebrada;
    public Sprite janelaConsertada;

    // Start is called before the first frame update
    void Start()
    {
    consertada = false;
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = janelaQuebrada;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(consertada){
        Debug.Log("consertada");
        
            sr.sprite = janelaConsertada;
        }else{
        Debug.Log("não consertada");
        
            sr.sprite = janelaQuebrada;
        }
    }

   
}
