using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    int MyCheckpoint;
    void Start()
    {
        GameManager manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        int i = 0;
        while(i != manager.CheckPoints.Length){
            if(manager.CheckPoints[i].transform == this.transform){
                MyCheckpoint = i;
                break;
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.tag=="Player"){
            Debug.Log("New Player start location at: " + this.transform.position);
            GameManager manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            manager.CurrentCheckpoint = MyCheckpoint;
            Debug.Log("New Checkpoint written.");
            BoxCollider2D box = this.gameObject.GetComponent<BoxCollider2D>();
            box.enabled = false;
            Debug.Log("Deactivated collider.");
        }

    }
}
