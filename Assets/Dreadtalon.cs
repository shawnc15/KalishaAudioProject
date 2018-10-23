using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dreadtalon : MonoBehaviour {

    // initialize attributes
    private Scene loadedLevel;
    public GameObject target;
    Vector3 acceleration;
    Vector3 direction;
    Vector3 desiredVelocity;
    Vector3 currentVelocity;
    Vector3 curPos;
    float maxSpeed;
    public float accelRate;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
