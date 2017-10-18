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

    public bool is_Unit_Test_1_passed_;
    public bool is_Unit_Test_2_passed_;
    public bool is_Unit_Test_3_passed_;

    public bool hasGameStarted;
    public int totalMoney;

    void Start() {
        nodes = GameObject.FindGameObjectsWithTag("node");
        if(minion_spawn_rate == 0) {
            minion_spawn_rate = 2;
        }
        number_of_minions = 0;
        hasGameStarted = false;
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

    public void Cost_Tower(int amount) {
        if (HasenoughMoney(amount)) {
            totalMoney -= amount;
        }
       
    }

    public bool HasenoughMoney(int amount) {
        if(totalMoney >= amount) {
            return true;
        }
        return false;
    }



    public void SceneChange_MainMenu() {
        Time.timeScale = 1.0f;
        Application.LoadLevel("MainMenu");
    }

    public void SceneChange_ReplayLevel() {
        Time.timeScale = 1.0f;
        Application.LoadLevel(Application.loadedLevelName);
    }


}
