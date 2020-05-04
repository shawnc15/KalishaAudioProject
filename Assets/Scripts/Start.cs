using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

    public string levelName;
    FMODUnity.StudioEventEmitter emitter;
    public GameObject ui;
    // Use this for initialization


    // Update is called once per frame
    void Update () {
		
	}

    public void StartGame()
    {
        emitter = ui.GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.Stop();
        SceneManager.LoadScene(levelName);
    }
}
