/* Purpose: Handles Node visibility, spawn rate and system factors
   Attached to: Manager */

using UnityEngine;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

    public GameObject[] nodes;
    public List<GameObject> totalMinions;   

    [HideInInspector]
    public float minion_spawn_rate;

    [HideInInspector]
    public int number_of_minions;

    private void OnEnable() {
        EventManager.MinionSpawnedMethods += IncrementMinionCount;
        EventManager.MinionDestroyedMethods += DecrementMinionCount;
    }

    private void OnDisable() {
        EventManager.MinionSpawnedMethods -= IncrementMinionCount;
        EventManager.MinionDestroyedMethods -= DecrementMinionCount;
    }

    void Start() {
        nodes = GameObject.FindGameObjectsWithTag("node");
        if(minion_spawn_rate == 0) {
            minion_spawn_rate = 2;
        }
        number_of_minions = 0;
    }

    public void SetNodeVisibility(bool isVisible) {       
        foreach (GameObject node in nodes) {
            node.GetComponent<MeshRenderer>().enabled = isVisible;
        }      
    }

    public void AddMinions(GameObject minion) {
        totalMinions.Add(minion);
    }

    public void SetSpawnRate(float spawnRate) {
        minion_spawn_rate = spawnRate;
    }

    public void IncrementMinionCount() {
        number_of_minions++;
    }

    public void DecrementMinionCount() {
        number_of_minions--;
    }
}
