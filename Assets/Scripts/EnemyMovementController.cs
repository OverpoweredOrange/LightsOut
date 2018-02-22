using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour {
    public GameObject player;
    public GameObject controller;
    bool gameRunning;

    NavMeshAgent agent;
    public float range;
    public bool activated;

    public float movDelayAmount;
    float currentMovDelay;
    bool delaying;

    bool lunging;
    public float lungeSpeed;
    public float lungeTimeAmount;
    float currentLungeTime;
    float originalAgentSpeed;

    void Start () {
        currentMovDelay = 0;
        currentLungeTime = 0;
        lunging = false;
        delaying = false;
        activated = false;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GameObject.FindGameObjectWithTag("GameController");
        gameRunning = controller.GetComponent<GameController>().gameRunning;
        agent.autoRepath = true;
        originalAgentSpeed = agent.speed;
    }

	void Update () {
        float dist = Vector3.Distance(player.transform.position, this.transform.position);
        gameRunning = controller.GetComponent<GameController>().gameRunning;

        if (delaying)
        {
            agent.isStopped = true;
            if(Time.time >= currentMovDelay)
            {
                delaying = false;
                agent.isStopped = false;
            }
        }

        if(lunging)
        {

            agent.speed = originalAgentSpeed + lungeSpeed;
            if (dist < 3)
            {
                lunging = false;
                agent.speed = originalAgentSpeed;
            }

            if (Time.time >= currentLungeTime)
            {
                lunging = false;
                agent.speed = originalAgentSpeed;
            }

        }
            
        if (dist <= range && activated && gameRunning && !delaying)
            agent.SetDestination(player.transform.position);

	}

    private void OnTriggerExit(Collider other)
    {
        if(!delaying && other.CompareTag("Sonar"))
        {
            currentMovDelay = Time.time + movDelayAmount;
            delaying = true;
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!lunging && other.CompareTag("Sonar"))
        {
            currentLungeTime = Time.time + lungeTimeAmount;
            lunging = true;
        }
    }
}
