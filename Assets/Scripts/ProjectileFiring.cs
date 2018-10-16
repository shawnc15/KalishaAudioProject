using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFiring : MonoBehaviour {

    private GameObject g_player;
    private List<GameObject> l_projectiles;
    public GameObject projectilePrefab;
    private GameObject g_placeholderProjectile;
    private float timer;
    public float interval;
    public string direction;

    // Use this for initialization
    void Start () {
        l_projectiles = new List<GameObject>();
        g_player = GameObject.Find("Player");
        timer = 0;
        interval = 100;
        
    }

    // Update is called once per frame
    void Update () {



        if (timer % 150 == 0)
        {
            g_placeholderProjectile = Instantiate(projectilePrefab);
            g_placeholderProjectile.transform.position = this.transform.position;
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
            /*
            if(l_projectiles[i].GetComponent<SpriteRenderer>().bounds.min.x < g_player.GetComponent<SpriteRenderer>().bounds.max.x && l_projectiles[i].GetComponent<SpriteRenderer>().bounds.max.x > g_player.GetComponent<SpriteRenderer>().bounds.min.x && l_projectiles[i].GetComponent<SpriteRenderer>().bounds.min.y < g_player.GetComponent<SpriteRenderer>().bounds.max.y && l_projectiles[i].GetComponent<SpriteRenderer>().bounds.max.y > g_player.GetComponent<SpriteRenderer>().bounds.min.x)
            {
                l_projectiles[i].SetActive(false);
                GameObject.Destroy(l_projectiles[i]);
                l_projectiles.Remove(l_projectiles[i]);
                i--;
                g_player.transform.position = new Vector3(0.0f,0.0f, g_player.transform.position.z);
            }*/
            
            switch (direction)
            {
                case "left":
                    l_projectiles[i].GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime);
                    if (l_projectiles[i].GetComponent<SpriteRenderer>().bounds.center.x < -8)
                    {
                        GameObject.Destroy(l_projectiles[i]);
                        l_projectiles.Remove(l_projectiles[i]);
                        i--;
                    }
                    break;
                case "right":
                    l_projectiles[i].GetComponent<Transform>().Translate(Vector3.right * Time.deltaTime);
                    if (l_projectiles[i].GetComponent<SpriteRenderer>().bounds.center.x > 8)
                    {
                        GameObject.Destroy(l_projectiles[i]);
                        l_projectiles.Remove(l_projectiles[i]);
                        i--;
                    }
                    break;
                case "up":
                    l_projectiles[i].GetComponent<Transform>().Translate(Vector3.up * Time.deltaTime);
                    if (l_projectiles[i].GetComponent<SpriteRenderer>().bounds.center.y > 6)
                    {
                        GameObject.Destroy(l_projectiles[i]);
                        l_projectiles.Remove(l_projectiles[i]);
                        i--;
                    }
                    break;
                case "down":
                    l_projectiles[i].GetComponent<Transform>().Translate(Vector3.down * Time.deltaTime);
                    if (l_projectiles[i].GetComponent<SpriteRenderer>().bounds.center.y < -6)
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

