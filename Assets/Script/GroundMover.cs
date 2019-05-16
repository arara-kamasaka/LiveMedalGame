using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    private float initZ;
    private Rigidbody rb;
    
    void Start()
    {
        initZ = transform.position.z;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var tmp = transform.position;
        tmp.z = initZ + Mathf.Sin(Time.frameCount * Mathf.Deg2Rad) * 1.5f;
        rb.MovePosition(tmp);
    }
}
