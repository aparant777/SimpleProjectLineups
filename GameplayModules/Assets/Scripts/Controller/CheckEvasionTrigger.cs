using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEvasionTrigger : MonoBehaviour {

    public Zombie zombie;
    public float evasionRate; //between 0 to 1;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "projectile") {
            if(evasionRate >= 0.8 && evasionRate <= 1) {
                //zombie.minionSpeed = 0f;
            }else if (evasionRate < 0.8 && evasionRate >= 0.3) {
                zombie.minionSpeed += 1.5f;
            } else if (evasionRate < 0.3 && evasionRate >=0) {
                zombie.minionSpeed += 5f;
            }
        }
        Debug.Log("evasion activated");
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "projectile") {
            if (evasionRate >= 0.8 && evasionRate <= 1) {
                //zombie.minionSpeed = 0f;
            }
            else if (evasionRate < 0.8 && evasionRate >= 0.3) {
                zombie.minionSpeed -= 1.5f;
            }
            else if (evasionRate < 0.3 && evasionRate >= 0) {
                zombie.minionSpeed -= 5f;
            }
        }
        Debug.Log("evasion deactivated");
    }
}
