using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraManager : MonoBehaviour
{
    public Transform PlayerTransform;

    public Vector3 MinPos;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        MinPos = this.gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(PlayerTransform.position.y < MinPos.y){
            this.gameObject.transform.position = MinPos;

        }
        else{
            Vector3 NewPos;
            NewPos = new Vector3(this.transform.position.x, PlayerTransform.position.y, this.transform.position.z);
            this.transform.position = NewPos;
        }
    }
}
