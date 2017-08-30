/* Purpose: Handles all UI functionality for the system
   Attached to: Canvas */

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Manager manager;

    private Text text_totalNumberOfMinions;
    private Text text_totalNumberOfMinions_value;
    private Text text_eventScrollData;

    private InputField inputfield_SpawnRate;

    private Button button_SpawnRate;
    private Button button_Quit;

    private Toggle ui_toggle_nodes;  
    private void OnEnable() {
        EventManager.MinionSpawnedMethods += UpdateTotalMinionsUI;
        EventManager.MinionSpawnedMethods += UpdateEventLog_Spawned;

        EventManager.MinionDestroyedMethods += UpdateTotalMinionsUI;
        EventManager.MinionDestroyedMethods += UpdateEventLog_Destroyed;

        EventManager.MinionInPathMethods += UpdateEventLog_InPath;
    }

    private void OnDisable() {
        EventManager.MinionSpawnedMethods -= UpdateTotalMinionsUI;
        EventManager.MinionSpawnedMethods -= UpdateEventLog_Spawned;

        EventManager.MinionDestroyedMethods -= UpdateTotalMinionsUI;
        EventManager.MinionDestroyedMethods -= UpdateEventLog_Destroyed;

        EventManager.MinionInPathMethods -= UpdateEventLog_InPath;
    }

    private void Start() {

        #region REFERENCES
        manager = GameObject.Find("Manager").GetComponent<Manager>();

        text_totalNumberOfMinions = GameObject.Find("Text-Total Number of Minions").GetComponent<Text>();
        text_totalNumberOfMinions_value = GameObject.Find("Text-Total Number of Minion-Value").GetComponent<Text>();
        text_eventScrollData = GameObject.Find("Content-Eventdata").GetComponent<Text>();

        inputfield_SpawnRate = GameObject.Find("InputField-Spawn Rate").GetComponent<InputField>();

        button_Quit = GameObject.Find("Button-Quit").GetComponent<Button>();
        button_SpawnRate = GameObject.Find("Button-Spawn Rate").GetComponent<Button>();

        ui_toggle_nodes = GameObject.Find("Toggle-ShowNodes").GetComponent<Toggle>();
        #endregion REFERENCES

        #region LISTENERS
        button_Quit.onClick.AddListener(() => OnClick_Quit());
        button_SpawnRate.onClick.AddListener(() => SetSpawnRate());
        ui_toggle_nodes.onValueChanged.AddListener((bool value) => ToggleNodes(ui_toggle_nodes.isOn));
        #endregion LISTENERS

    }

    public void ToggleNodes(bool isVisible) {
        manager.SetNodeVisibility(isVisible);
    }

    public void SetSpawnRate() {
        float spawnRate = (float.Parse(inputfield_SpawnRate.text));        
        manager.SetSpawnRate(spawnRate);
    }

    public void UpdateTotalMinionsUI() {
        text_totalNumberOfMinions_value.text = manager.number_of_minions.ToString();
    }

    public void UpdateEventLog_Destroyed() {
        string temp = text_eventScrollData.text;
        text_eventScrollData.text = temp + System.Environment.NewLine + "minion destoryed";
    }

    public void UpdateEventLog_Spawned() {
        string temp = text_eventScrollData.text;
        text_eventScrollData.text = temp + System.Environment.NewLine + "minion spawned";
    }

    public void UpdateEventLog_InPath() {
        string temp = text_eventScrollData.text;
        text_eventScrollData.text = temp + System.Environment.NewLine + "minion in path";
    }

    private void OnClick_Quit() {
        Application.Quit();
    }
}
