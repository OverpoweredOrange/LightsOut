using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevealScript : MonoBehaviour {

    public Color colorStart;
    public Color color1;
    public Color color2;
    List<Color> colors = new List<Color>();
    public Renderer rend;

    PlayerController playercontrollerscript;
    bool destroyable;

    public Image proximityAlarm;
    Color safe;
    Color danger;

    void Start () {
            colorStart = Color.black;
            color1 = Color.red;
            color2 = Color.blue;
            safe = Color.green;
        danger = Color.red;
        rend = GetComponent<Renderer>();
        rend.material.color = colorStart;
        destroyable = false;
        colors.Add(color1);
        colors.Add(color2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sonar"))
        {
            if (this.gameObject.CompareTag("Enemy") && !this.gameObject.GetComponent<EnemyMovementController>().activated)
                this.gameObject.GetComponent<EnemyMovementController>().activated = true;
                
            rend.material.color = colors[Random.Range(0,colors.Count)];
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Sonar"))
        {
            destroyable = true;
            proximityAlarm.color = danger;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sonar"))
        {
            rend.material.color = colorStart;
            destroyable = false;
            proximityAlarm.color = safe;
        }
    }
}
