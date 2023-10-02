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

    public Vector2 Acellerometer;

    public Vector2 Mouse;
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

        AcellerometerControlls();

        Acellerometer = Input.acceleration;
        Mouse = Input.mousePosition;

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

    void EditorControls()
    {
if(Input.GetKey(KeyCode.Space)){
            JumpPress();
        }
     if(Input.GetKeyUp(KeyCode.Space)){
        JumpRelease();
     }
    }

    public void JumpPress(){
        BonusSpeed += (Time.deltaTime * 0.1f);
    }

    public void JumpRelease(){
        myrigid.AddForce(Vector2.up * (Speed * (1 + BonusSpeed)), ForceMode2D.Impulse);
        BonusSpeed = 0;
    }

    void AcellerometerControlls(){
        if(isAirborne){
            Vector2 AcelNormalised = new Vector2(Acellerometer.x,0);

            myrigid.AddForce(AcelNormalised * 8,ForceMode2D.Impulse);
            
        }
    }
}
