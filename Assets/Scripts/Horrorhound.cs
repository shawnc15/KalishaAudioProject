using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Horrorhound : MonoBehaviour {
    public Animator animator;
    private int step;
    private Vector3 position;
    public Vector3 velocity;
    public Vector3 acceleration;
    private float accelRate;
    public float maxSpeed;
    private Vector3 direction;
    private Vector3 start;
    private Vector3 end;
    private Transform[] path;
    public GameObject[] pathObjects;
    private Scene loadedLevel;
    public GameObject g_player;
    private int waitTimer;

    // Use this for initialization
    void Start () {
        g_player = GameObject.Find("Player");
        path = new Transform[pathObjects.GetLength(0)];
        for (int i = 0; i < pathObjects.GetLength(0); i++)
        {
            path[i] = pathObjects[i].transform;
        }
        step = 0;
        start = path[0].localPosition;
        end = path[1].localPosition;
        accelRate = maxSpeed * 10.0f;
        position = transform.localPosition;
        loadedLevel = SceneManager.GetActiveScene();
        waitTimer = 20;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        SetDirection();
        Move();
        CheckPosition();
        animator.SetFloat("xSpeed", Mathf.Abs(velocity.x));
        animator.SetFloat("ySpeed", velocity.y);
        if(velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.localPosition = position;
        position = transform.localPosition;
	}

    void NextStep()
    {
        velocity = new Vector2(0, 0);
        step++;
        step %= path.GetLength(0);
        start = path[step].localPosition;
        end = path[(step + 1) % path.GetLength(0)].localPosition;
    }
    
    void CheckPosition()
    {
        if (waitTimer <= 0)
        {
            float distance = (end - transform.localPosition).magnitude;
            waitTimer = 20;
            if (distance <= 0.6f)
            {
                NextStep();
            }
        }
        waitTimer--;
    }

    void SetDirection()
    {
        direction = (end - position).normalized;
    }

    void Move()
    {
        acceleration = accelRate * direction;
        velocity += acceleration;        
        // get that acceleration thing from mouse guard
        if (velocity.magnitude > maxSpeed)
        {
            velocity = maxSpeed * direction;
        }
        position += velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            SceneManager.LoadScene(loadedLevel.buildIndex);
        }
        if (collision.gameObject.tag == "box")
        {
            NextStep();
        }
    }

}
