using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState{Null, PreGame, InGame, GameFinished}
    public GameState gameState;
    public bool GamePaused;

    GameUserInterface UI;
    PlayerManager Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOvercheck();
    }

    void GameOvercheck(){
        if(Player.Lives < 1){
            GameOver();
        }
        
    }

    public void SetUI(GameUserInterface gameUserInterface){
        UI = gameUserInterface;
    }

    public void FinishLevel(){
        Debug.Log("Begin Finish level.");
        UI.OpenCompletedLevelScreen();
        
    }

    public void GameOver(){
        UI.OpenGameOverscreen();
    }
}
