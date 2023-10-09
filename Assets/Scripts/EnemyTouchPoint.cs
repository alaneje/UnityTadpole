using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchPoint : MonoBehaviour
{

    public Enemy myenemy;
    // Start is called before the first frame update
    void Start()
    {
        myenemy = gameObject.GetComponentInParent<Enemy>();

        Debug.Log(myenemy.Health.x);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        Debug.Log("Testing new click point");
        myenemy.OnEnemyClick();
    }
}
