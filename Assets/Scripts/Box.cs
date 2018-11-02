using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public Vector3 velocity;
    public bool collide;
    Rigidbody2D boxBody;
    bool touchingPlayer;


    // Use this for initialization
    void Start()
    {
        touchingPlayer = false;
        boxBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Constrain();
        //transform.position = position;
        //velocity = new Vector2(0, 0);

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

    string CheckWhere(GameObject obstacle)
    {
        float isForwardOrBehind = Vector2.Dot(obstacle.transform.position - transform.position, Vector2.up);
        float rightOrLeft = Vector3.Dot(obstacle.transform.position - transform.position, Vector2.right);
        // obstacle is in front of object
        if (isForwardOrBehind > 0.7)
        {
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
        if(collision.gameObject.tag == "player")
        {
            touchingPlayer = true;
        }
        if (collision.gameObject.tag != "player")
        {
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            Vector2 collisionPos = new Vector2(collision.transform.position.x, collision.transform.position.y);
            Vector2 distance = position - collisionPos;
            Vector2 collDir = collision.gameObject.GetComponent<Transform>().position;

            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;

            switch (CheckWhere(collision.gameObject))
            {
                case "right":
                case "left":
                    velocity.x = -velocity.x;
                    transform.position = new Vector2(transform.position.x + velocity.x/10, transform.position.y);
                    break;
                case "up":
                case "down":
                    velocity.y = -velocity.y;
                    transform.position = new Vector2(transform.position.x, transform.position.y + velocity.y/ 10);
                    break;
                default:
                    break;
            }

            if (!touchingPlayer)
            {
                GetComponent<Rigidbody2D>().mass = 100000;
            }
            if (touchingPlayer)
            {
                GetComponent<Rigidbody2D>().mass = 0;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            touchingPlayer = false;
        }
        GetComponent<Rigidbody2D>().mass = 0;
    }
}
