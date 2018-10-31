using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move: MonoBehaviour {

    public float moveRate = .11f;
    public Animator animator;
    public Rigidbody2D playerBody;
    public Vector3 moveVector = Vector3.zero;
    private Scene loadedLevel;
    // Use this for initialization
    void Start () {
        loadedLevel = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        MovementInput();
        animator.SetFloat("xSpeed", Mathf.Abs(moveVector.x));
        animator.SetFloat("ySpeed", moveVector.y);
        //Debug.Log(Mathf.Abs(moveVector.x));
        ResetLevel();
    }

    public void MovementInput()
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

    public void ResetLevel()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(loadedLevel.buildIndex);
        }
    }
}
