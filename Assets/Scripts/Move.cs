using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour {

    public float moveRate = .11f;
    public Animator animator;
    public Rigidbody2D playerBody;
    Vector3 moveVector = Vector3.zero;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovementInput();
        animator.SetFloat("xSpeed", Mathf.Abs(moveVector.x));
        animator.SetFloat("ySpeed", moveVector.y);
        //Debug.Log(Mathf.Abs(moveVector.x));
    }

    private void MovementInput()
    {
        moveVector = Vector3.zero;
        if (Input.GetAxis("moveUp") > 0)
        {
            moveVector += Vector3.up;
            
        }
        else if (Input.GetAxis("moveUp") < 0)
        {
            moveVector += Vector3.down;
        }

        if (Input.GetAxis("moveRight") > 0)
        {
            moveVector += Vector3.right;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetAxis("moveRight") < 0)
        {
            moveVector += Vector3.left;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        moveVector = moveVector.normalized * moveRate;

        playerBody.velocity = moveVector;
    }
}
