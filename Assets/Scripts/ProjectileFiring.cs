using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFiring : MonoBehaviour {
    public Animator animator;
    private GameObject g_player;
    private List<GameObject> l_projectiles;
    public GameObject projectilePrefab;
    private GameObject g_placeholderProjectile;
    private float timer;
    public float interval;
    public string direction;
    public float speed;

    // Use this for initialization
    void Start () {
        l_projectiles = new List<GameObject>();
        g_player = GameObject.Find("Player");
        timer = 0;
        switch (direction)
        {
            case "left":
                animator.SetBool("sideways", true);
                animator.GetParameter(0);
                GetComponent<SpriteRenderer>().flipX = true;
                break;
            case "right":
                animator.SetBool("sideways", true);
                animator.GetParameter(0);
                GetComponent<SpriteRenderer>().flipX = false;
                break;
            case "up":
                animator.SetBool("up", true);
                animator.GetBool(1);
                GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0,0, 90.0f));
                break;
            case "down":
                animator.SetBool("down", true);
                animator.GetBool(2);
                GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, -90.0f));
                break;
            default:
                break;
        }

    }

    // Update is called once per frame
    void Update () {
        if (timer % 150 == 0)
        {
            g_placeholderProjectile = Instantiate(projectilePrefab);
            g_placeholderProjectile.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            switch (direction)
            {
                case "left":
                    g_placeholderProjectile.GetComponent<SpriteRenderer>().flipX = true;
                    break;
                case "right":
                    g_placeholderProjectile.GetComponent<SpriteRenderer>().flipX = false;
                    break;
                case "up":
                    g_placeholderProjectile.GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 0.0f));
                    break;
                case "down":
                    g_placeholderProjectile.GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 0.0f));
                    break;
                default:
                    break;
            }
            g_placeholderProjectile.GetComponent<SpriteRenderer>().sortingOrder = 1;
            l_projectiles.Add(g_placeholderProjectile);
            
        }

        Collision();

        Movement();

        timer++;
    }

    void Collision()
    {

    }

    void Movement()
    {
        for (int i = 0; i < l_projectiles.Count; i++)
        {
            
            switch (direction)
            {
                case "left":
                    l_projectiles[i].GetComponent<Transform>().Translate((Vector3.left * speed) * Time.deltaTime);
                    if (l_projectiles[i].GetComponent<SpriteRenderer>().bounds.center.x < -15)
                    {
                        GameObject.Destroy(l_projectiles[i]);
                        l_projectiles.Remove(l_projectiles[i]);
                        i--;
                    }
                    break;
                case "right":
                    l_projectiles[i].GetComponent<Transform>().Translate((Vector3.right * speed) * Time.deltaTime);
                    if (l_projectiles[i].GetComponent<SpriteRenderer>().bounds.center.x > 15)
                    {
                        GameObject.Destroy(l_projectiles[i]);
                        l_projectiles.Remove(l_projectiles[i]);
                        i--;
                    }
                    break;
                case "up":
                    l_projectiles[i].GetComponent<Transform>().Translate((Vector3.right * speed) * Time.deltaTime);
                    if (l_projectiles[i].GetComponent<SpriteRenderer>().bounds.center.y > 15)
                    {
                        GameObject.Destroy(l_projectiles[i]);
                        l_projectiles.Remove(l_projectiles[i]);
                        i--;
                    }
                    break;
                case "down":
                    l_projectiles[i].GetComponent<Transform>().Translate((Vector3.right * speed) * Time.deltaTime);
                    if (l_projectiles[i].GetComponent<SpriteRenderer>().bounds.center.y < -15)
                    {
                        GameObject.Destroy(l_projectiles[i]);
                        l_projectiles.Remove(l_projectiles[i]);
                        i--;
                    }
                    break;
                default:
                    break;
            }
            
            



        }
    }
}

