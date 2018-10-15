using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour {

    public float moveRate = .11f;

    public Rigidbody2D playerBody;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovementInput();
	}

    private void MovementInput()
    {
        Vector3 moveVector = Vector3.zero;
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

        }
        else if (Input.GetAxis("moveRight") < 0)
        {
            moveVector += Vector3.left;
        }

        moveVector = moveVector.normalized * moveRate;

        playerBody.velocity = moveVector;
    }
}
