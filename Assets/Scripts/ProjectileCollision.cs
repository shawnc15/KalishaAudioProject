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
        if(collision.collider.tag == "player")
        {
            g_player.transform.position = new Vector3(0.0f,0.0f,this.transform.position.z);
            this.gameObject.SetActive(false);
        }
    }
}
