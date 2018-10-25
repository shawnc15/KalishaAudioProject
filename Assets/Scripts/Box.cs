using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    public Vector3 velocity;
    public bool collide;
    Rigidbody2D boxBody;
	// Use this for initialization
	void Start () {
        boxBody = GetComponent<Rigidbody2D>();
        collide = false;
        velocity = boxBody.velocity;
	}
	
	// Update is called once per frame
	void Update () {
        Constrain();
        

        velocity = boxBody.velocity;

    }

    void Constrain()
    {
       
        if (boxBody.velocity.magnitude > 0)
        {
            Vector3 tempVelocity = boxBody.velocity;

            if (boxBody.velocity.x > boxBody.velocity.y)
            {
                tempVelocity.y = 0;
            }
            else
            {
                tempVelocity.x = 0;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "box")
        {
           // boxBody.mass = 10.0f;
        }
        if (collision.collider.tag == "wall")
        {
            
        }
        if (collision.collider.tag == "talon")
        {
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "box")
        {
           // boxBody.mass = 0.01f;
        }
        if (collision.collider.tag == "talon")
        {

        }
    }

}
