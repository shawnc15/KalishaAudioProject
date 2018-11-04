using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {

    bool inInstructions;
    public GameObject startButton;
    public GameObject quitButton;
    public GameObject backButton;
    public Sprite[] sprites;

	// Use this for initialization
	void Start () {
        inInstructions = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InstructionsToggle()
    {
        if (!inInstructions)
        {
            startButton.SetActive(false);
            quitButton.SetActive(false);
            GetComponent<Image>().sprite = sprites[1];
            inInstructions = true;
        }
        else
        {
            startButton.SetActive(true);
            quitButton.SetActive(true);
            GetComponent<Image>().sprite = sprites[0];
            inInstructions = false;
        }
    }
}
