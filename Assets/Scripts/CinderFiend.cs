using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinderFiend : MonoBehaviour
{

    public GameObject target;
    public float speed;
    private Vector2 velocity;
    private float distance;
    private Scene loadedLevel;
    public Rigidbody2D fiendBody;
    private bool startExplode;
    Vector2 moveVector = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        loadedLevel = SceneManager.GetActiveScene();
        fiendBody = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("player");
        startExplode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startExplode)
            Seek();
    }

    void Seek()
    {
        velocity = new Vector2((target.transform.position.x - transform.position.x), (target.transform.position.y - transform.position.y));
        moveVector = velocity.normalized * speed;
        fiendBody.velocity = moveVector;
        transform.forward = velocity.normalized;
    }

    void Explode()
    {
        StartCoroutine(Wait());
        Debug.Log("boom");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //SceneManager.LoadScene(loadedLevel.buildIndex);
            startExplode = true;
            Explode();

        }
        if (collision.gameObject.tag == "box")
        {

        }
    }
}
