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
    private bool slow;
    // Use this for initialization
    void Start () {
        loadedLevel = SceneManager.GetActiveScene();
        slow = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        MovementInput();
        animator.SetFloat("xSpeed", Mathf.Abs(moveVector.x));
        animator.SetFloat("ySpeed", moveVector.y);
        //Debug.Log(Mathf.Abs(moveVector.x));
        ResetLevel();
        Debug.Log(slow);
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

        if (slow)
            playerBody.velocity = (moveVector) / 2.0f;
        else
            playerBody.velocity = moveVector;
    }

    public void ResetLevel()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(loadedLevel.buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sand")
        {
            slow = true;
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sand")
        {
            slow = false;
        }

    }
}
