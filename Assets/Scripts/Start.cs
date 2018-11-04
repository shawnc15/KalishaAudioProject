using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

    public string levelName;

    // Use this for initialization

	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene(levelName);
    }
}
