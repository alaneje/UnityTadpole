using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Canon : MonoBehaviour
{
    public GameObject Ball;

    public float FireFrequency;

    public float StartDelay;

    public Vector2Int DirectionOfBall;

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
             SimpleHazard canonball = Instantiate(Ball.GetComponent<SimpleHazard>(), this.transform.position, Quaternion.identity);
             canonball.Direction = DirectionOfBall;
                Timer = FireFrequency;
            }
        }
        
    }
}
