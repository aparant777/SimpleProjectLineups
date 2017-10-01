using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public GameObject objectToSpawn;
    public PoolingManager poolingManager;


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            objectToSpawn = SpawnObject();           
        }
    }

    private GameObject SpawnObject() {
        return poolingManager.GetObjectFromPool();
    }
}
