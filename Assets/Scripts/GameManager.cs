using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState{Null, PreGame, InGame, GameFinished}
    public GameState gameState;
    public bool GamePaused;

    GameUserInterface UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUI(GameUserInterface gameUserInterface){
        UI = gameUserInterface;
    }

    public void FinishLevel(){
        Debug.Log("Begin Finish level.");
        UI.OpenCompletedLevelScreen();
        
    }
}
