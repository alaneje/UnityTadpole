using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public int Lives;

    public int Points;
    public float Speed;
    public int MaxJumps;

    public SpriteRenderer MySpriteRenderer;

    public int ToungeBaseDamage;

    public GameObject Tounge;

    float BonusSpeed;

    bool isAirborne;

    Rigidbody2D myrigid;

    Vector2 MyVelocity;

    Vector3 Acellerometer;

    bool ClickDown;

    

    bool isGrounded;

    bool Stuck;

    int jumpsremaining;

    Vector2 ToungeAim;

    float Toungelerp;

    float InvicyFrameTime;

    float InvincyFrameLerper;

    bool InvincyTimeDirection = true;

    bool InvincyTime;
    
    float InvincyFrameLerpSpeed = 2;
   

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        myrigid = this.gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        
        Respawn(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.isEditor){
            EditorControls();
        }
        
        AirbornCheck();

        ClickDownMan();

        AcellerometerControlls();

        ToungeManager();

        Acellerometer = Input.acceleration;
        
        if(isGrounded && myrigid.velocity == Vector2.zero){
            ResetJumpCount();
        }

       
        InvincyTimer();
        InvincyTimeAnimation();
    }

    void InvincyTimer(){
        if(InvincyTime){
            InvicyFrameTime -= Time.deltaTime;
        }
        if(InvicyFrameTime < 0){
            InvicyFrameTime = 0;
            InvincyTime=false;
        }
    }

    public void SetInvinceabilityFrames(float Timer){
        InvicyFrameTime = Timer;
        InvincyTime = true;
    }

    void InvincyTimeAnimation(){
        if(InvincyTime){
            
            if(InvincyTimeDirection){
                InvincyFrameLerper += (Time.deltaTime * InvincyFrameLerpSpeed);
            }
            else{
                InvincyFrameLerper -= (Time.deltaTime * InvincyFrameLerpSpeed);
            }

            if(InvincyFrameLerper > 1){InvincyTimeDirection = false;}
            if(InvincyFrameLerper < 0){InvincyTimeDirection = true;}
            
            
            MySpriteRenderer.color = Color.Lerp(Color.white,Color.red,InvincyFrameLerper);
        }
    }

    public int ReturnToungeDamage(Enemy.EnemyType type){
        return ToungeBaseDamage;
    }

    public void Respawn(bool StartOfLevel){
        GameManager GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        Lives = 3;//need to change
        int Checkp = 0;
        if(!StartOfLevel){
            Checkp = GM.CurrentCheckpoint;
        }
        
        this.transform.position = GM.CheckPoints[Checkp].position;
    }

    void AirbornCheck(){
        MyVelocity = myrigid.velocity;
        if(myrigid.velocity.y > 0){
            isAirborne = true;
        }
        else{
            isAirborne = false;
        }
    }

    void ToungeManager(){
        if(ToungeAim != Vector2.zero){
            Tounge.transform.position = Vector2.Lerp(this.transform.position, ToungeAim, Toungelerp);
            Toungelerp += (Time.deltaTime * 2);
            Tounge.GetComponent<CircleCollider2D>().enabled = true;
            Vector3 SoftVector = new Vector3(ToungeAim.x, ToungeAim.y, this.transform.position.z);
            if(Tounge.transform.position == SoftVector){
                Tounge.transform.position = this.transform.position;
                ToungeAim = Vector2.zero;
                Toungelerp = 0;
            }

            
        }
        else{
            Tounge.GetComponent<CircleCollider2D>().enabled = false;
        }

    }

void ClickDownMan(){
    if(ClickDown){
        if(BonusSpeed < gameManager.JumpMax){
            BonusSpeed += (Time.deltaTime * 0.1f);
        }

    }
}
    void EditorControls()
    {
if(Input.GetKeyDown(KeyCode.Space)){
            JumpPress();
        }
     if(Input.GetKeyUp(KeyCode.Space)){
        JumpRelease();
     }
    }

    public void JumpPress(){
        ClickDown = true;
        
    }

   public bool canJump(){
        if(jumpsremaining > 0){
            return true;
        }
        else
        {
            return false;
        }
    }

    public void JumpRelease(){
        ClickDown = false;
        if(Stuck){
            myrigid.AddForce(Vector2.up * Speed, ForceMode2D.Impulse);
        }
        else{
            myrigid.AddForce(Vector2.up * (Speed * (1 + BonusSpeed)), ForceMode2D.Impulse);
        }
        
        isGrounded = false;
        jumpsremaining -=1;
        BonusSpeed = 0;
    }

    void AcellerometerControlls(){
        if(isAirborne){
            const float AccelMultiplyer = 8;
            Vector2 AcelNormalised = new Vector2(Acellerometer.x * (Time.deltaTime * AccelMultiplyer),0);

            myrigid.AddForce(AcelNormalised,ForceMode2D.Impulse);
            
        }
    }

public void TakeDamage(){
    if(!InvincyTime){
    myrigid.velocity = Vector2.zero;//kill movement
    Lives -= 1;

    SetInvinceabilityFrames(2);
    
    }
    
}

void ResetJumpCount(){  
    jumpsremaining = MaxJumps;
        
    
}

    void OnCollisionEnter2D(Collision2D col)
    {
    if(col.gameObject.tag == "Enemy"){
        Debug.Log("Enemy Hit");
        Enemy enemy = col.gameObject.GetComponent<Enemy>();
        if(enemy==null){
            Debug.LogErrorFormat("NO ENEMY SCRIPT ON THIS ENEMY. ABORTING.");
            return;
        }
    if(enemy.OnCollisionDamage){
        TakeDamage();
    }

    

}

if(col.gameObject.tag=="Floor"){
        //ResetJumpCount();
    }

    


    }//end of col

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.tag);

        if(col.tag == "Collectable"){
            Points++;
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Enemy"){
        Debug.Log("Enemy Hit");
        Enemy enemy = col.gameObject.GetComponent<Enemy>();
        if(enemy==null){
            Debug.LogErrorFormat("NO ENEMY SCRIPT ON THIS ENEMY. ABORTING.");
            return;
        }
    if(enemy.OnCollisionDamage){
        TakeDamage();
    }
    }
    }

    void OnTriggerStay2D(Collider2D col){
        if(col.tag=="Ooze"){
            Stuck = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.tag == "Ooze"){
            Stuck = false;
        }
    }

    public void ToungeClick(Vector2 Origin){
        float Test = Vector2.Distance(this.transform.position, Origin);
        Debug.Log("Distance between objects: " + Test);
        if(Test < 6){
            ToungeAim = Origin;
        }   
        
    }

    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag=="Floor"){
        isGrounded = true;
    }
    }

    void OnCollisionExit2D(Collision2D col){
        isGrounded = false;
    }

    public float GetJumpBonus(){
        return BonusSpeed;
    }
}
