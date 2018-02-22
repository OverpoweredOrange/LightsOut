using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public bool gameRunning;
    PlayerController player;

    public Text counter;
    public Text YouWin;
    public int count;

    void Start () {
        count = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameRunning = true;
    }

    // Update is called once per frame
    void Update () {
        player.gameRunning = gameRunning;
        counter.text = count.ToString();

        if (count == 7)
        {
            gameRunning = false;
            YouWin.text = "You Win! Press any key to restart.";
        }

        if( count < 7 && !gameRunning)
        {
            YouWin.text = "You Lose! Press any key to restart.";
        }

        if (!gameRunning && Input.anyKey)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
