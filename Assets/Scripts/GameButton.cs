using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{

    public string type = "Start Game";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
    if(type == "Start Game"){
        PlayerMove.score = 0;
        PlayerMove.hp = 100;
        PlayerMove.level = 1;
        SceneManager.LoadScene("Floor1");
    }if(type == "Game Rules"){
        SceneManager.LoadScene("GameRules");
    }if(type == "Options"){
        SceneManager.LoadScene("Options");
    }
    if(type == "Back"){
        SceneManager.LoadScene("MainMenu");
    }
    if(type == "Menu"){
    PlayerMove.score = 0;
        PlayerMove.hp = 100;
        PlayerMove.level = 0;
        
        SceneManager.LoadScene("MainMenu");
    }
    if(type == "Try Again"){
    PlayerMove.score = 0;
        PlayerMove.hp = 100;
       
        PlayerMove.level = 1;
        SceneManager.LoadScene("Floor1");
    }
    if(type == "Next Level"){
    PlayerMove.score += PlayerMove.stageScore;
        PlayerMove.stageScore = 0;
       
        PlayerMove.level += 1;
        int l = PlayerMove.level % 4;
        switch(l){
        case 1:
        SceneManager.LoadScene("Floor1");
        break;

        case 2:
        SceneManager.LoadScene("Floor2");
        break;

        case 3:
        SceneManager.LoadScene("Floor3");
        break;

        default:
        SceneManager.LoadScene("Terrace");
        break;
        }
        
    }
    if(type == "Quit"){
        Application.Quit();
    }
    }
}
