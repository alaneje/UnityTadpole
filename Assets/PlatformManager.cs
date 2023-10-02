using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y - 2 < this.gameObject.transform.position.y){
            boxCollider2D.enabled = false;
        }
        else
        {boxCollider2D.enabled = true;}
        
    }
}
