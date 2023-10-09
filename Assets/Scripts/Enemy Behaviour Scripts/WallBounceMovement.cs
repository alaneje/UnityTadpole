using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounceMovement : MonoBehaviour
{
    public bool FlipOnDirection;
    public bool StartsAimingRight;

    public float Speed;
    Enemy myEnemy;
    Rigidbody2D rigidbody2D;

    SpriteRenderer myspriterenderer;

    Vector2 MovementVec;

    float ResetTime;
    void Start()
    {
        myEnemy = this.gameObject.GetComponent<Enemy>();
        rigidbody2D = myEnemy.GetRigid();
        myspriterenderer = this.gameObject.GetComponent<SpriteRenderer>();

        MovementVec = Vector2.right;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        rigidbody2D.velocity = (MovementVec * Speed);

        if(ResetTime > 0){
            ResetTime -= Time.deltaTime;
        }

        SpriteUpdate();

        
    }

    void SpriteUpdate(){

        if(FlipOnDirection){

            if(StartsAimingRight){
                if(MovementVec == Vector2.right)
                {
                    myspriterenderer.flipX = false;
                }
                if(MovementVec == Vector2.left)
                {
                    myspriterenderer.flipX = true;
                }
            }
            else{
                if(MovementVec == Vector2.right)
                {
                    myspriterenderer.flipX = true;
                }
                if(MovementVec == Vector2.left)
                {
                    myspriterenderer.flipX = false;
                }

            }


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
