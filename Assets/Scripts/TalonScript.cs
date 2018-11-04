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
        target = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update ()
    {
        Rotate();
        Seek();
	}

    void Seek()
    {
        velocity = new Vector2((target.transform.position.x - transform.position.x), (target.transform.position.y - transform.position.y ));
        moveVector = velocity.normalized * speed;
        birdBody.velocity = moveVector;
    }

    void Rotate()
    {
        Vector3 toTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
