using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHazard : MonoBehaviour
{   
    Rigidbody2D Me;
    public bool DestroyOnContact;

    public bool DestroyWhenOffScreen;

    public float ObjectSpeed;
    public Vector2Int Direction;
    // Start is called before the first frame update
    void Start()
    {
        if(Direction != Vector2Int.zero){
            Me = this.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Direction != Vector2Int.zero){
            Travel();
        }
    }

    void Travel(){
        Vector2 Dir = Direction;
        Me.AddForce(Dir * ObjectSpeed,ForceMode2D.Force);

    }
    void OnBecameInvisible(){
        if(DestroyWhenOffScreen){
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D Col){
        Debug.Log(Col.gameObject.tag);
        if(Col.gameObject.tag == "Player"){

            PlayerManager playerManager = Col.gameObject.GetComponent<PlayerManager>();
            playerManager.TakeDamage();
            if(DestroyOnContact){
                Destroy(this.gameObject);
            }
        }
    }
}
