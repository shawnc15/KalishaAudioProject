using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    private GameObject[] gameObjects;
    bool isPaused;

	// Use this for initialization
	void Start () {
        gameObjects = UnityEngine.GameObject.FindObjectsOfType<GameObject>();
        isPaused = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            Pause();
        }

    }

    public void Pause()
    {
        foreach (var item in gameObjects)
        {
            if (item.tag == "pause")
            {
                item.SetActive(true);
            }
            else if (item.tag != "manager")
            {
                item.SetActive(false);
            }
        }
        isPaused = true;
    }
    public void Unpause()
    {
        foreach (var item in gameObjects)
        {
            if (item.tag == "pause")
            {
                item.SetActive(true);
            }
            else if (item.tag != "manager")
            {
                item.SetActive(false);
            }
        }
        isPaused = true;
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Title");
    }

}
