using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SonarClient : MonoBehaviour {
    public float delayAmount;
    float currentDelay;
    bool delaying = false;

    void Start()
    {
        currentDelay = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sonar"))
        {
            this.gameObject.layer = 13;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sonar"))
        {
            delaying = true;
            currentDelay = Time.time + delayAmount;
        }
    }

    void FixedUpdate()
    {
        if (delaying && Time.time >= currentDelay)
        {
                delaying = false;
                this.gameObject.layer = 12;
        }
    }
}