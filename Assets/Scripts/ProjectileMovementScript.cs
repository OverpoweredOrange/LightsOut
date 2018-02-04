using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementScript : MonoBehaviour {

    Transform ts;
    public float speed;
	// Use this for initialization
	void Start () {
        ts = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        ts.Translate(Vector3.forward * speed * Time.deltaTime );
	}
}

