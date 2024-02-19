using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public string EnemyName;
    public enum EnemyType{Null, ExplodeOnImpact}

    
    public Vector2Int Health;
    public EnemyType enemyType;
    public bool OnCollisionDamage;
    Rigidbody2D MyRigid;
    Vector3 Startpos;
    bool Blocked;
    float blocktimer;
    // Start is called before the first frame update
    void Awake()
    {
        MyRigid = this.gameObject.GetComponent<Rigidbody2D>();
        Startpos = this.gameObject.transform.position;
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
        if(enemyType == EnemyType.ExplodeOnImpact){
            Blockcheck();
        }
    }

    void HealthOverloadcheck(){
        if(Health.x > Health.y){
            Health.x = Health.y;
        }
    }

    void Blockcheck(){
        this.gameObject.GetComponent<SpriteRenderer>().enabled = !Blocked;
        this.gameObject.GetComponent<Collider2D>().enabled = !Blocked;

        if(blocktimer > 0){
            blocktimer -= Time.deltaTime;

        }
        if(blocktimer < 0){
            blocktimer = 0;
            Blocked = false;
        }
    }

    void DeathCheck(){
        if(Health.x < 1){
           GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
           gameManager.KillEnemy(enemyType, EnemyName);
           PlayerManager player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
           player.Points+=5;
           Destroy(this.gameObject);

        }
    }
    void OnCollisionEnter2D(Collision2D col){
        Debug.Log(col.gameObject.tag + "Collided");
        if(col.gameObject.tag == "Player" && enemyType == EnemyType.ExplodeOnImpact){
            Blocked = true;
            blocktimer = 5;
            this.transform.position = Startpos;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.gameObject.tag + "Triggerd");
        if(col.gameObject.tag=="Tounge"){
            Debug.Log("Hit by tounge! trigger");
        PlayerManager player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        Health.x -= player.ReturnToungeDamage(enemyType);

    }
    }

    public void OnEnemyClick(){
        PlayerManager player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        player.ToungeClick(this.transform.position);
    }

    void OnMouseDown(){
        
    }
}
