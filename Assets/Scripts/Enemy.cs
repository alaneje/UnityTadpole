using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool OnCollisionDamage;
    Rigidbody2D MyRigid;
    // Start is called before the first frame update
    void Awake()
    {
        MyRigid = this.gameObject.GetComponent<Rigidbody2D>();
        
    }
    public Rigidbody2D GetRigid(){
        return MyRigid;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
