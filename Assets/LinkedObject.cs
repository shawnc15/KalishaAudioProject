using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedObject : MonoBehaviour {

    
    public Rigidbody2D linked;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        linked.velocity += collision.relativeVelocity;
    }
}
