﻿using System.Collections;
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
    private bool pause;
    public AudioClip pickup;
    public AudioClip death;
    public AudioClip portal;

    public bool dying;
 

    // Use this for initialization
    void Start () {
        loadedLevel = SceneManager.GetActiveScene();
        slow = false;
        pause = false;
        dying = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        MovementInput();
        animator.SetFloat("xSpeed", Mathf.Abs(moveVector.x));
        animator.SetFloat("ySpeed", moveVector.y);
        HotKeys();
        if (dying)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                SceneManager.LoadScene(loadedLevel.buildIndex);
            }
        }
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

    public void HotKeys()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(loadedLevel.buildIndex);
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sand")
        {
            slow = true;
        }

        if (collision.gameObject.tag == "shard")
        {
      
            //GetComponent<AudioSource>().clip = pickup;
            //GetComponent<AudioSource>().Play();
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hound" || collision.gameObject.tag == "talon" || collision.gameObject.tag == "bullet")
        {
            if (!dying)
            {
                GetComponent<AudioSource>().clip = death;
                GetComponent<AudioSource>().Play();
                dying = true;
                GetComponent<Transform>().transform.Translate(new Vector3(0.0f, 0.0f, -100.0f));
            }
            
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
