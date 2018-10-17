using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileCollision : MonoBehaviour {

    private GameObject g_player;
    private Scene loadedLevel;

    // Use this for initialization
    void Start () {
        g_player = GameObject.Find("Player");
        loadedLevel = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "player")
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(loadedLevel.buildIndex);
        }

        if(collision.collider.tag == "box")
        {
            this.gameObject.SetActive(false);
        }
    }
}
