using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public float Speed;

    public float BonusSpeed;

    public bool isAirborne;

    Rigidbody2D myrigid;

    public Vector2 MyVelocity;

    public Vector3 Acellerometer;

    public bool ClickDown;

    
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

    public void JumpRelease(){
        ClickDown = false;
        myrigid.AddForce(Vector2.up * (Speed * (1 + BonusSpeed)), ForceMode2D.Impulse);
        BonusSpeed = 0;
    }

    void AcellerometerControlls(){
        if(isAirborne){
            const float AccelMultiplyer = 8;
            Vector2 AcelNormalised = new Vector2(Acellerometer.x * (Time.deltaTime * AccelMultiplyer),0);

            myrigid.AddForce(AcelNormalised,ForceMode2D.Impulse);
            
        }
    }
}
