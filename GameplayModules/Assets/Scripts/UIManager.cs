using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Toggle ui_toggle_nodes;  //toggles the visibility of nodes
    public Manager manager;
    
    public Button button_SpawnRate;
    public InputField inputfield_SpawnRate;
    
    private void Start() {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    public void ToggleNodes(bool isVisible) {
        manager.SetNodeVisibility(isVisible);
    }

    public void SetSpawnRate() {
        int spawnRate = (int.Parse(inputfield_SpawnRate.text));
        Debug.Log("Spawn rate is " + spawnRate);
        manager.SetSpawnRate(spawnRate);
    }
}
