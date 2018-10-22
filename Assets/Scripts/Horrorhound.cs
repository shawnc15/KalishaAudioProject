using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Horrorhound : MonoBehaviour {

    private float speed;
    private int step;
    private Vector3 position;
    private Vector3 velocity;
    private Vector3 acceleration;
    private float accelRate;
    public float maxSpeed;
    private Vector3 direction;
    private Vector3 start;
    private Vector3 end;
    private Transform[] path;
    public GameObject[] pathObjects;
    private Scene loadedLevel;
    public GameObject g_player;

    // Use this for initialization
    void Start () {
        g_player = GameObject.Find("Player");
        path = new Transform[pathObjects.GetLength(0)];
        for (int i = 0; i < pathObjects.GetLength(0); i++)
        {
            path[i] = pathObjects[i].transform;
        }
        step = 0;
        start = path[0].position;
        end = path[1].position;
        accelRate = maxSpeed * 10.0f;
        position = transform.position;
        //Debug.Log(transform.position + GetComponentInParent<Transform>().position);
        loadedLevel = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update () {
        Move();
        CheckPosition();
        direction = (end - position).normalized;
        
        //Debug.Log(direction);
        transform.position = position;
	}

    void NextStep()
    {
        step++;
        step %= path.GetLength(0);
        start = path[step].position;
        end = path[(step + 1) % path.GetLength(0)].position;
        //Debug.Log("Start: " + start);
        //Debug.Log("End: " + end);
    }
    
    void CheckPosition()
    {
        float distance = (end - transform.position).magnitude;
        
        if (distance <= 0.2f)
        {
            //Debug.Log("Next");
            NextStep();
        }
    }

    void Move()
    {
        acceleration = accelRate * direction * Time.deltaTime;
        velocity += acceleration;
        // get that acceleration thing from mouse guard
        Debug.Log(acceleration);
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
    }

}
