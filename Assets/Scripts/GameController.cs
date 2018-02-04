using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool gameRunning;
    PlayerController player;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameRunning = true;
    }

    // Update is called once per frame
    void Update () {
        player.gameRunning = gameRunning;
    }
}
