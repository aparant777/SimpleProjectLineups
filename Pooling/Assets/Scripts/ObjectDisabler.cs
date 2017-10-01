using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour {

    public PoolingManager poolingManager;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            poolingManager.ResetObject(other.gameObject);            
        }
    }
}
