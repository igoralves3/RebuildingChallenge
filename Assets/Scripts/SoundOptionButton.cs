using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOptionButton : MonoBehaviour
{
    public TextMesh tm;
    public static float soundVolume=0.5F;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        if(soundVolume == 0.5f){
        tm.text = "Full sound";
            soundVolume = 1.0f;
        }else if(soundVolume == 1.0f){
        tm.text = "No sound";
            soundVolume = 0.0f;
        }else{
        tm.text = "With sound";
            soundVolume = 0.5f;
        }
    }
}
