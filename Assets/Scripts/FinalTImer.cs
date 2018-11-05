using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTImer : MonoBehaviour {


    public int interval;
    private int timer;
    // Use this for initialization
    void Start () {
        timer = 0;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (timer == interval)
            SceneManager.LoadScene("Title");
        timer++;

	}
}
