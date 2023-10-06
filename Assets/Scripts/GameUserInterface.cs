using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameUserInterface : MonoBehaviour
{
    public Button JumpButton;
    public GameObject CompletedLevelPannel;
    public TextMeshProUGUI LivesText;

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



//Buttons

public void ReturnToMenu(bool Save){

}
    public void JumpPress(){
        player.JumpPress();
    }

    public void JumpRelease(){
        player.JumpRelease();
    }
}
