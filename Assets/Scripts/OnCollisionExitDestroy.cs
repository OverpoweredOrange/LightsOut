using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionExitDestroy : MonoBehaviour {
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("PlayerAttack"))
        Destroy(other.gameObject);
    }
}
