using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Canon : MonoBehaviour
{
    public GameObject Ball;

    public float FireFrequency;

    public float StartDelay;

    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = FireFrequency;
    }

    // Update is called once per frame
    void Update()
    {

        if(StartDelay > 0){
            StartDelay -= Time.deltaTime;
        }
        else{
            Timer -= Time.deltaTime;
            if(Timer < 0){
                Instantiate(Ball, this.transform.position, Quaternion.identity);
                Timer = FireFrequency;
            }
        }
        
    }
}
