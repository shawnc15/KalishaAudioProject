﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public GameObject[] gameObjects;
    GameObject[] bullets;
    bool isPaused;

	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(this);
        gameObjects = FindObjectsOfType<GameObject>();
        isPaused = false;
        foreach (var item in gameObjects)
        {
            if (item.tag == "pause")
            {
                item.SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("Music Volume",0.8f);
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Pause", transform.position);
            Pause();
        }
    }

    public void Pause()
    {
        bullets = GameObject.FindGameObjectsWithTag("bullet");
        foreach (var item in gameObjects)
        {
            if (item.tag == "pause")
            {
                item.SetActive(true);
            }
            else if (item.tag != "manager" && item.tag != "MainCamera")
            {
                item.SetActive(false);
            }
        }
        foreach (var item in bullets)
        {
            item.SetActive(false);
        }
        isPaused = true;
    }
    public void Unpause()
    {
        foreach (var item in gameObjects)
        {
            if (item.tag == "pause")
            {
                item.SetActive(false);
            }
            else if (item.tag != "manager" && item.tag != "MainCamera" || item.tag == "Untagged")
            {
                item.SetActive(true);
            }
        }
        foreach (var item in bullets)
        {
            item.SetActive(false);
        }
        GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("Music Volume", 1f);
        isPaused = false;
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    public void ReturnToMenu()
    {
        isPaused = false;
        foreach (var item in gameObjects)
        {
            if (item.tag == "pause")
            {
                item.SetActive(false);
            }
        }
        GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        SceneManager.LoadScene("Title");
    }

}
