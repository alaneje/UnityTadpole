using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounceMovement : MonoBehaviour
{
    
    Enemy myEnemy;
    Rigidbody2D rigidbody2D;

    Vector2 MovementVec;

    float ResetTime;
    void Start()
    {
        myEnemy = this.gameObject.GetComponent<Enemy>();
        rigidbody2D = myEnemy.GetRigid();

        MovementVec = Vector2.right;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        rigidbody2D.velocity = MovementVec;

        if(ResetTime > 0){
            ResetTime -= Time.deltaTime;
        }

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        if(col.gameObject.tag == "Wall" && ResetTime < 1){
            if(MovementVec == Vector2.right){
                MovementVec = Vector2.left;
                Debug.Log("Moving Left");
                return;
            }
            if(MovementVec == Vector2.left){
                MovementVec = Vector2.right;
                Debug.Log("Moving Right");
                return;
            }
        }
    }
}
