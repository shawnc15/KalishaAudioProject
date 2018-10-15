using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    bool switchOn = false;

    public Color activatedColor;

    SpriteRenderer switchRenderer;

    //List<string> collidingNames;
    int numCollisions;

    private void Start()
    {
        switchRenderer = GetComponent<SpriteRenderer>();
    }

    void ToggleEnable()
    {
        switchOn = !switchOn;

        if (switchOn)
        {
            switchRenderer.color = Color.blue;
        }
        else
        {
            switchRenderer.color = Color.white;
        }
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the gameobject hasn't already collided with the switch (preventing double collisions)
        //if (collidingNames.Contains(collision.gameObject.name)==false){
        //collidingNames.Add(collision.gameObject.name);
        //}

        //Mark that the object has collided
        ++numCollisions;

        //If this is the object's first collision
        if (switchOn == false)
        {
            ToggleEnable();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Mark that the object is no longer colliding with the switch.
        --numCollisions;

        //If there are no longer any objects colliding.
        if (numCollisions == 0)
        {
            ToggleEnable();
        }
    }
   

}
