using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public string EnemyName;
    public enum EnemyType{Null}

    
    public Vector2Int Health;
    public EnemyType enemyType;
    public bool OnCollisionDamage;
    Rigidbody2D MyRigid;
    // Start is called before the first frame update
    void Awake()
    {
        MyRigid = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    void Start(){
        Health.x = Health.y;
    }
    public Rigidbody2D GetRigid(){
        return MyRigid;
    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();
        HealthOverloadcheck();
    }

    void HealthOverloadcheck(){
        if(Health.x > Health.y){
            Health.x = Health.y;
        }
    }

    void DeathCheck(){
        if(Health.x < 1){
           GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
           gameManager.KillEnemy(enemyType, EnemyName);
           Destroy(this.gameObject);

        }
    }
    void OnCollisionEnter2D(Collision2D col){
        Debug.Log(col.gameObject.tag);
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag=="Tounge"){
            Debug.Log("Hit by tounge! trigger");
        PlayerManager player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        Health.x -= player.ReturnToungeDamage(enemyType);

    }
    }

    void OnMouseDown(){
        PlayerManager player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        player.ToungeClick(this.transform.position);
    }
}
