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
    public BoxCollider2D fiendCollider;
    private bool startExplode;
    public Vector2 ExplosionSize;
    public bool boom;
    Vector2 moveVector = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        loadedLevel = SceneManager.GetActiveScene();
        fiendBody = this.GetComponent<Rigidbody2D>();
        fiendCollider = this.GetComponent<BoxCollider2D>();
        target = GameObject.FindGameObjectWithTag("player");
        startExplode = false;
        boom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startExplode)
        {
            Rotate();
            Seek();
        }
        else if (!boom && startExplode)
        {
            fiendBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            this.transform.localScale += new Vector3(0.01f, 0.01f, 0.0f);
        }

        if (boom)
        {
            StartCoroutine(death());
        }
           
    }

    void Seek()
    {
        velocity = new Vector2((target.transform.position.x - transform.position.x), (target.transform.position.y - transform.position.y));
        moveVector = velocity.normalized * speed;
        fiendBody.velocity = moveVector;
    }

    void Rotate()
    {
        Vector3 toTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Explode()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("boom");
        boom = true;
        fiendCollider.size = ExplosionSize;
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            startExplode = true;
            Explode();
            if (boom)
            {
                SceneManager.LoadScene(loadedLevel.buildIndex);
            }

        }
        if (collision.gameObject.tag == "box")
        {

        }
    }
}
