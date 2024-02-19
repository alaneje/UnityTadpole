using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateSpriteTowardPlayer : MonoBehaviour
{

    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        //this.gameObject.transform.LookAt(Player.transform, Vector3.forward);

        Quaternion rotation = Quaternion.LookRotation(
        Player.transform.position - transform.position ,
        transform.TransformDirection(Vector3.back)
        );
        transform.rotation = new Quaternion( 0 , 0 , rotation.z , rotation.w );
    }
}
