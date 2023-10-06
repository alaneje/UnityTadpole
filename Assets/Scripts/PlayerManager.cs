using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public int Lives;
    public float Speed;
    public int MaxJumps;

    float BonusSpeed;

    public bool isAirborne;

    Rigidbody2D myrigid;

    public Vector2 MyVelocity;

    public Vector3 Acellerometer;

    bool ClickDown;

    

    bool isGrounded;

    int jumpsremaining;

    // Start is called before the first frame update
    void Start()
    {
        myrigid = this.gameObject.GetComponent<Rigidbody2D>();
        

        
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

        Acellerometer = Input.acceleration;
        
        if(isGrounded && myrigid.velocity == Vector2.zero){
            ResetJumpCount();
        }

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

void ClickDownMan(){
    if(ClickDown){
BonusSpeed += (Time.deltaTime * 0.1f);
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

    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag=="Floor"){
        isGrounded = true;
    }
    }

    void OnCollisionExit2D(Collision2D col){
        isGrounded = false;
    }
}
