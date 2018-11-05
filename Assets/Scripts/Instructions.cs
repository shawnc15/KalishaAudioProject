using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {

    bool inInstructions;
    public GameObject startButton;
    public GameObject quitButton;
    public GameObject instructionsButton;
    public Sprite[] sprites;
    public GameObject title;

    // Use this for initialization
    void Start()
    {
        inInstructions = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstructionsToggle()
    {
        if (!inInstructions)
        {
            //Debug.Log("HELLO");
            startButton.SetActive(false);
            quitButton.SetActive(false);
            instructionsButton.SetActive(true);
            title.SetActive(false);
            GetComponent<Image>().sprite = sprites[1];
            Vector3 position = GetComponent<RectTransform>().position;
            position.y = Screen.height / 7;
            position.x = Screen.width / 2;
            GetComponent<RectTransform>().position = position;
            //GetComponent<RectTransform>().sizeDelta = new Vector2(550, 500);
           // GetComponentInChildren<Text>().text = "Back";
            inInstructions = true;

        }
        else
        {
            startButton.SetActive(true);
            quitButton.SetActive(true);
            instructionsButton.SetActive(false);
            title.SetActive(true);

            GetComponent<Image>().sprite = sprites[0];
            Vector3 position = GetComponent<RectTransform>().position;
            position.y = Screen.height / 2.5f;
            position.x = Screen.width / 2.6f;
            GetComponent<RectTransform>().position = position;
            //GetComponent<RectTransform>().sizeDelta = new Vector2(300, 80);
            //GetComponentInChildren<Text>().text = "Instructions";
            inInstructions = false;
        }
    }
}
