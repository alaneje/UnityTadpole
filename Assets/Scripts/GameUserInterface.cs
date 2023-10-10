using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameUserInterface : MonoBehaviour
{
    public Button JumpButton;
    public GameObject CompletedLevelPannel;
    public GameObject GameOverpannel;
    public TextMeshProUGUI LivesText;

    public Image JumpBar;

    GameManager gameManager;
    PlayerManager player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        gameManager.SetUI(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLives();
        UpdateJumpButton();
        UpdateJumpBar();
    }

    void UpdateJumpBar(){
        JumpBar.fillAmount = ReturnStatasOne(player.GetJumpBonus(),gameManager.JumpMax);

    }
    
    void UpdateJumpButton(){
        JumpButton.interactable = player.canJump();
    }

    void UpdateLives(){
        LivesText.text = player.Lives.ToString();
    }

    public void OpenCompletedLevelScreen(){
        CompletedLevelPannel.SetActive(true);
    }

    public void OpenGameOverscreen(){
        GameOverpannel.SetActive(true);
    }


//Buttons

public void ReturnToMenu(bool Save){

}

public void RespawnInGame(){
    player.Respawn(false);//respawn the player at the last checkpoint
    GameOverpannel.SetActive(false);
}
    public void JumpPress(){
        if(JumpButton.interactable){
            player.JumpPress();
        }
        
    }

    public void JumpRelease(){
        if(JumpButton.interactable){
            player.JumpRelease();
        }
        
    }

    float ReturnStatasOne(float Current, float Max)
    {
        float C = Current;
        float M = Max;

        float T = C / M;
        return T;
    }
}
