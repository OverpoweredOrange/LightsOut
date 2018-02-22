using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SonarClient : MonoBehaviour {

    //sonar delay varibles
    public float delayAmount;
    float currentDelay;
    public bool delaying;
    public GameObject controller;
    bool gameRunning;

    void Start()
    {
        delaying = false;
        currentDelay = 0;
        controller = GameObject.FindGameObjectWithTag("GameController");
        gameRunning = controller.GetComponent<GameController>().gameRunning;
    }

    private void Update()
    {
        gameRunning = controller.GetComponent<GameController>().gameRunning;
        if(!gameRunning)
            this.gameObject.layer = 13;

        if (delaying && Time.time >= currentDelay)
        {
            delaying = false;
            this.gameObject.layer = 12;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sonar"))
        {
            if (gameObject.CompareTag("Enemy") && !gameObject.GetComponent<EnemyMovementController>().activated)
            {
                gameObject.GetComponent<EnemyMovementController>().activated = true;
            }
                

            this.gameObject.layer = 13;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Sonar"))
            this.gameObject.layer = 13;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sonar"))
        {
            delaying = true;
            currentDelay = Time.time + delayAmount;
        }
    }
}