using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEvasionTrigger : MonoBehaviour {

    public Zombie zombie;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "projectile") {
            zombie.minionSpeed += 2.5f; 
        }
        Debug.Log("evasion activated");
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "projectile") {
            zombie.minionSpeed -= 2.5f;
        }
        Debug.Log("evasion deactivated");
    }
}
