using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {

    private GameObject g_player;


    // Use this for initialization
    void Start () {
        g_player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "player" || collision.collider.tag == "box")
        {
            this.gameObject.SetActive(false);
        }

        
    }
}
