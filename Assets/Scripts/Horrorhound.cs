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
        if (transform.localPosition.y != 0.0f)
        {
            Debug.Log("REEEE");
        }
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
            //Debug.Log(distance);
            if (distance <= 0.6f)
            {
               // Debug.Log("Next");
                NextStep();
            }
        }
        waitTimer--;
    }

    void SetDirection()
    {
        direction = (end - position).normalized;

        Debug.Log(direction);
    }

    void Move()
    {
        acceleration = accelRate * direction;
        velocity += acceleration;        
        Debug.Log(acceleration);
        //Debug.Log(direction);
        // get that acceleration thing from mouse guard
        //Debug.Log(acceleration);
        if (velocity.magnitude > maxSpeed)
        {
            velocity = maxSpeed * direction;
        }
        //Debug.Log(velocity);
        position += velocity;
        //Debug.Log(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {

           // g_player.transform.position = new Vector3(0.0f, 0.0f, this.transform.position.z);
            //this.gameObject.SetActive(false);
            SceneManager.LoadScene(loadedLevel.buildIndex);
        }
        if (collision.gameObject.tag == "box")
        {
            NextStep();
        }
    }

}


/*
 * using System.Collections;
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
    private float lengthTime;
    private float fStartTime;
    private float fPercentage;

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
        
        fStartTime = Time.time;
        lengthTime = Vector2.Distance(path[step].position, path[(step + 1) % path.GetLength(0)].position);
        fPercentage = 0.0f;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {
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
        transform.position = position;
	}

    void NextStep()
    {
        velocity = new Vector2(0, 0);
        fStartTime = Time.time;
        lengthTime = Vector2.Distance(path[step].position, path[(step + 1) % path.GetLength(0)].position);
        fPercentage = 0.0f;
        step++;
        step %= path.GetLength(0);
        start = path[step].position;
        end = path[(step + 1) % path.GetLength(0)].position;
    }
    
    void CheckPosition()
    {
        if (fPercentage >= 1.0f)
        {
            NextStep();
        }
    }

    void SetDirection()
    {
        direction = (end - transform.position).normalized;
        //if (direction.x > 0)
        //{
        //    direction = Vector2.right;
        //}
        //else if (direction.x < 0)
        //{
        //    direction = Vector2.left;
        //}
        //else if (direction.y > 0)
        //{
        //    direction = Vector2.up;
        //}
        //else if (direction.y < 0)
        //{
        //    direction = Vector2.down;
        //}
        Debug.Log(direction);
    }

    void Move()
    {
        float distanceCovered = (Time.time - fStartTime) * maxSpeed;
        fPercentage = distanceCovered / lengthTime; 

        position = Vector2.Lerp(start, end, fPercentage);
        acceleration = accelRate * direction;
        velocity += acceleration;        
        Debug.Log(acceleration);
        //Debug.Log(direction);
        // get that acceleration thing from mouse guard
        //Debug.Log(acceleration);
        if (velocity.magnitude > maxSpeed)
        {
            velocity = maxSpeed * direction;
        }
        //Debug.Log(velocity);
        transform.position += velocity;
        //Debug.Log(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "player")
    {

        // g_player.transform.position = new Vector3(0.0f, 0.0f, this.transform.position.z);
        //this.gameObject.SetActive(false);
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }
    if (collision.gameObject.tag == "box")
    {
        NextStep();
    }
}

}
*/
