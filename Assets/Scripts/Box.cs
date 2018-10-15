using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {


    Rigidbody2D boxBody;
	// Use this for initialization
	void Start () {
        boxBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Constrain();
	}

    void Constrain()
    {
       
            if (boxBody.velocity.magnitude >0)
            {
                Vector3 tempVelocity = boxBody.velocity;

                if (boxBody.velocity.x>boxBody.velocity.y)
                {
                    tempVelocity.y = 0;
                }
                else
                {
                    tempVelocity.x = 0;
                }
            }
        }
   
}
