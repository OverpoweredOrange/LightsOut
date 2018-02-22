using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyCollisionGameOver : MonoBehaviour {
    public GameObject controller;

    void Start () {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            controller.GetComponent<GameController>().gameRunning = false;
        }
    }
}
