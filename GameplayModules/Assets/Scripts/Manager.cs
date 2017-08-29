using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject[] nodes;
    public List<GameObject> totalMinions;   //just to keep track of everyone for clearing them all later and for display/events
    public int minion_spawn_rate;
    void Start() {
        nodes = GameObject.FindGameObjectsWithTag("node");
        if(minion_spawn_rate == 0) {
            minion_spawn_rate = 2;
        }
    }

    public void SetNodeVisibility(bool isVisible) {       
        foreach (GameObject node in nodes) {
            node.GetComponent<MeshRenderer>().enabled = isVisible;
        }      
    }

    public void AddMinions(GameObject minion) {
        totalMinions.Add(minion);
    }

    public void SetSpawnRate(int spawnRate) {
        minion_spawn_rate = spawnRate;
    }
}
