using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform PlayerAttackTransform;
    public GameObject projectile;

    public SphereCollider sonar;
    bool canSonar;
    bool sonarActive;
    public float sonarSpeed;
    public float maxSonarRadius;

    public GameController gameController;

    public bool gameRunning;


    public float speed;
    public float rotationSpeed;

    public float bulletSpeed;


    void Start () {
        canSonar = true;
        sonarActive = false;
        sonar.radius = 0;

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        //Sonar Controls
        if(Input.GetButtonDown("Fire2") && canSonar)
        {
            sonarActive = true;
            canSonar = false;
        }

        if(sonarActive)
        {
            sonar.radius += Time.deltaTime * sonarSpeed;
            if(sonar.radius >= maxSonarRadius)
            {
                sonarActive = false;
                canSonar = true;
                sonar.radius = 0;
            }
        }


    }

    void FixedUpdate () {
        //Movement
        if (gameRunning)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }

        //Fire 
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject clone = Instantiate(projectile, PlayerAttackTransform.position, PlayerAttackTransform.rotation);
            clone.GetComponent<ProjectileMovementScript>().speed = bulletSpeed;
        }
    }
}
