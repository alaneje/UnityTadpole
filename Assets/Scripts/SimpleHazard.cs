using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D Col){
        Debug.Log(Col.gameObject.tag);
        if(Col.gameObject.tag == "Player"){

            PlayerManager playerManager = Col.gameObject.GetComponent<PlayerManager>();
            playerManager.TakeDamage();
        }
    }
}
