using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerInRange : MonoBehaviour
{
    public PlayerManager player;

    public bool TurnOffWhenColliderIsOff;
    public float AcceptedRange;
    public float Speed;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool CanAct = true;
        if(TurnOffWhenColliderIsOff){
            if(this.gameObject.GetComponent<Collider2D>().enabled == false){CanAct = false;}
        }
        if(PlayerInRange() && CanAct){
            Debug.Log("PLAYER IN RANGE.");
            this.gameObject.transform.position =  Vector3.MoveTowards(this.gameObject.transform.position , player.transform.position, Time.deltaTime * Speed);
        }
    }

    bool PlayerInRange(){
        if(Vector3.Distance(this.gameObject.transform.position,player.gameObject.transform.position) < AcceptedRange){
            return true;
        }
        else{
            return false;
        }

        
    }//Looks at if a player is in range to the object
}
