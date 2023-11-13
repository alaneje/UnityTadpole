using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectablerotation : MonoBehaviour
{

    Transform mytransform;
    // Start is called before the first frame update
    void Start()
    {
        mytransform = this.gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mytransform.Rotate(Vector3.forward);
    }
}
