using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalonScript : MonoBehaviour {

    public GameObject target;
    public float speed;
    private Vector2 velocity;
    private float distance;
    private Scene loadedLevel;
    public Rigidbody2D birdBody;
    Vector2 moveVector = Vector3.zero;

    // Use this for initialization
    void Start ()
    {
        loadedLevel = SceneManager.GetActiveScene();
        birdBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        Seek();
	}

    void Seek()
    {
        velocity = new Vector2((target.transform.position.x - transform.position.x), (target.transform.position.y - transform.position.y ));
        moveVector = velocity.normalized * speed;
        birdBody.velocity = moveVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            SceneManager.LoadScene(loadedLevel.buildIndex);
        }
        if (collision.gameObject.tag == "box")
        {
            
        }
    }
}
