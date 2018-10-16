using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinorShard : MonoBehaviour {

    public bool collected = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collected = true;
        }
    }
}
