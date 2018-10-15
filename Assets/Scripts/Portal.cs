using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public GameObject portPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {

     

        //Move the position of the object.
        collision.gameObject.transform.position = portPosition.transform.position;



        
    }
}
