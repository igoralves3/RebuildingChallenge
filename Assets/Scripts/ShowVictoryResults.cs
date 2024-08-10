using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowVictoryResults : MonoBehaviour
{

        //GUIStyle style;

    // Start is called before the first frame update
    void Start()
    {
        //style = new GUIStyle();

        //style.fontSize = 20;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var m = GameObject.FindGameObjectWithTag("Status").GetComponent<TextMesh>();
        m.text = "HP: "+PlayerMove.hp;
        m.text += "\nStage Score: " + (PlayerMove.stageScore);
        m.text +="\nTotal Score: " + (PlayerMove.stageScore+PlayerMove.score);
    }

    void OnGUI(){
        //GUI.Label(new Rect(Screen.width/2-10,Screen.height/2-20,100,20),"HP: "+PlayerMove.hp.ToString(),style);
        //GUI.Label(new Rect(Screen.width/2-10,Screen.height/2,100,20),"Stage Score: "+PlayerMove.stageScore.ToString(),style);
        //GUI.Label(new Rect(Screen.width/2-10,Screen.height/2+20,100,20),"Total Score: "+PlayerMove.score.ToString(),style);
    }
}
