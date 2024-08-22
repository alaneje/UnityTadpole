using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraManager : MonoBehaviour
{
    public Transform PlayerTransform;

    public Vector3 MinPos;
    public Vector3 CameraOffset = new Vector3(0,-5,0);
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        MinPos = gameObject.transform.position + CameraOffset;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(PlayerTransform.position.y < MinPos.y){
            gameObject.transform.position = MinPos;
        }
        else{
            Vector3 NewPos = new Vector3(transform.position.x, PlayerTransform.position.y, transform.position.z);
            transform.position = NewPos;
        }
    }
}
