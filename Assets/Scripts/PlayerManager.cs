using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public int Lives;
    public float Speed;
    public int MaxJumps;

    public int ToungeBaseDamage;

    public GameObject Tounge;

    float BonusSpeed;

    bool isAirborne;

    Rigidbody2D myrigid;

    Vector2 MyVelocity;

    Vector3 Acellerometer;

    bool ClickDown;

    

    bool isGrounded;

    int jumpsremaining;

    Vector2 ToungeAim;

    float Toungelerp;

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
        myrigid.AddForce(Vector2.up * (Speed * (1 + BonusSpeed)), ForceMode2D.Impulse);
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
    myrigid.velocity = Vector2.zero;//kill movement
    Lives -= 1;
    InvokeInvincabilityFrames();
}

void ResetJumpCount(){  
    jumpsremaining = MaxJumps;
        
    
}



void InvokeInvincabilityFrames(){

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
