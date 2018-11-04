using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    bool switchOn = false;

    public List<GameObject> walls = new List<GameObject>();

    //List<string> collidingNames;
    int numCollisions;

    private void Start()
    {
        
    }

    void ToggleEnable()
    {
        switchOn = !switchOn;

        if (switchOn)
        {
            //switchRenderer.color = Color.blue;
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].GetComponent<SpriteRenderer>().enabled = false;
                walls[i].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
            //switchRenderer.color = Color.white;
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].GetComponent<SpriteRenderer>().enabled = true;
                walls[i].GetComponent<BoxCollider2D>().enabled = true;
            }
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
