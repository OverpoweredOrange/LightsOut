using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//acting weird

public class RevealScript : MonoBehaviour {

    public Color colorStart = Color.black;
    public Color colorEnd = Color.red;
    public Renderer rend;

    PlayerController playercontrollerscript;

    bool gameRunning;
    bool destroyable;

    public Image proximityAlarm;
    public Color safe;
    public Color danger;

    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = colorStart;
        destroyable = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playercontrollerscript = player.GetComponent<PlayerController>();
        gameRunning = playercontrollerscript.gameRunning;
    }

    private void Update()
    {
        gameRunning = playercontrollerscript.gameRunning;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightCollider"))
        {
            rend.material.color = colorEnd;
            destroyable = true;
            proximityAlarm.color = danger;
        }

        if (other.CompareTag("PlayerAttack") && destroyable)
        {
            Destroy(this.gameObject);
        }
        else if(other.CompareTag("PlayerAttack") && !destroyable)
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LightCollider"))
        {
            rend.material.color = colorStart;
            destroyable = false;
            proximityAlarm.color = safe;
        }
    }
}
