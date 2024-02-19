using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Player"){
            if(col.gameObject.GetComponent<PlayerManager>().Lives > 0){
                gameManager.FinishLevel();
            }
                
        }
       // Debug.Log("Trigger is: " + col.gameObject.tag);
        
    }
}
