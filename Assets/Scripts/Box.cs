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
	void FixedUpdate () {
        Constrain();
        //transform.position = position;
        //velocity = new Vector2(0, 0);
    }

    void Constrain()
    {
       
            if (boxBody.velocity.magnitude > 0)
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

    string CheckWhere(GameObject obstacle)
    {        
        float isForwardOrBehind = Vector2.Dot(obstacle.transform.position - transform.position, Vector2.up);
        float rightOrLeft = Vector3.Dot(obstacle.transform.position - transform.position, Vector2.right);
        // obstacle is in front of object
        if (isForwardOrBehind > 0.7)
        {

            Debug.Log("RIGHT OR LEFT " + rightOrLeft);
            return "up";
        }
        else if (isForwardOrBehind < -0.7)
        {
            return "down";
        }
        // object is to the left of object, and within it's radius
        else if (rightOrLeft < -0.8)
        {
            return "left";
        }
        // object is to the left of object, and within it's radius
        else if (rightOrLeft > 0.8)
        {
            return "right";
        }
       

        return "Nothing";
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "player")
        { 
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            Vector2 collisionPos = new Vector2(collision.transform.position.x, collision.transform.position.y);
            Vector2 distance = position - collisionPos;
            Vector2 collDir = collision.gameObject.GetComponent<Transform>().position;
            //Debug.Log(CheckWhere(collision.gameObject));

            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            switch (CheckWhere(collision.gameObject))
            {
                case "right":
                case "left":
                    velocity.x = 0;
                    break;
                case "up":
                case "down":
                    velocity.y = 0;
                    break;
                default:
                    break;
            }

        }
    }

}
