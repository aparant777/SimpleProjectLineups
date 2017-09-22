/* Purpose: Handles all UI functionality for the system
   Attached to: Canvas */

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Manager manager;
    private MinionSpawner minionSpawner;

    private Text text_totalNumberOfMinions;
    private Text text_totalNumberOfMinions_value;
    private Text text_eventScrollData;
    private Text text_AIbaseHealth;
    private Text text_AIBaseHealth_value;
    public Text text_test_result_1;
    public Text text_test_result_2;
    public Text text_test_result_3;

    private InputField inputfield_SpawnRate;

    private Button button_SpawnRate;
    private Button button_Quit;

    private Toggle ui_toggle_nodes;
    private Toggle ui_toggle_controlledSpawning;

    private GameObject panel_GameOver;

    //private void OnEnable() {
    //    EventManager.MinionSpawnedMethods += UpdateTotalMinionsUI;
    //    EventManager.MinionSpawnedMethods += UpdateEventLog_Spawned;

    //    EventManager.MinionDestroyedMethods += UpdateTotalMinionsUI;
    //    EventManager.MinionDestroyedMethods += UpdateEventLog_Destroyed;

    //    EventManager.MinionInPathMethods += UpdateEventLog_InPath;

    //    EventManager.MinionDestroyedMethods += UpdateEventLog_Takingdamage;
    //}

    //private void OnDisable() {
    //    EventManager.MinionSpawnedMethods -= UpdateTotalMinionsUI;
    //    EventManager.MinionSpawnedMethods -= UpdateEventLog_Spawned;

    //    EventManager.MinionDestroyedMethods -= UpdateTotalMinionsUI;
    //    EventManager.MinionDestroyedMethods -= UpdateEventLog_Destroyed;

    //    EventManager.MinionInPathMethods -= UpdateEventLog_InPath;

    //    EventManager.MinionDestroyedMethods -= UpdateEventLog_Takingdamage;
    //}

    private void Start() {

        #region REFERENCES
        manager = GameObject.Find("Manager").GetComponent<Manager>();

        minionSpawner = GameObject.Find("Minion Spawner").GetComponent<MinionSpawner>();

        text_totalNumberOfMinions = GameObject.Find("Text-Total Number of Minions").GetComponent<Text>();
        text_totalNumberOfMinions_value = GameObject.Find("Text-Total Number of Minion-Value").GetComponent<Text>();
        text_eventScrollData = GameObject.Find("Content-Eventdata").GetComponent<Text>();
        text_AIBaseHealth_value = GameObject.Find("Text_AIBaseHealth_Value").GetComponent<Text>();
        text_test_result_1 = GameObject.Find("Text-test11").GetComponent<Text>();
        text_test_result_2 = GameObject.Find("Text-test22").GetComponent<Text>();
        text_test_result_3 = GameObject.Find("Text-test33").GetComponent<Text>();

        inputfield_SpawnRate = GameObject.Find("InputField-Spawn Rate").GetComponent<InputField>();

        button_Quit = GameObject.Find("Button-Quit").GetComponent<Button>();
        button_SpawnRate = GameObject.Find("Button-Spawn Rate").GetComponent<Button>();

        ui_toggle_nodes = GameObject.Find("Toggle-ShowNodes").GetComponent<Toggle>();

        ui_toggle_controlledSpawning = GameObject.Find("Toggle-Is Controlled Spawn").GetComponent<Toggle>();

        panel_GameOver = GameObject.Find("Panel-GameOver");
        #endregion REFERENCES

        #region LISTENERS
        button_Quit.onClick.AddListener(() => OnClick_Quit());
        button_SpawnRate.onClick.AddListener(() => SetSpawnRate());
        ui_toggle_nodes.onValueChanged.AddListener((bool value) => ToggleNodes(ui_toggle_controlledSpawning.isOn));
        ui_toggle_controlledSpawning.onValueChanged.AddListener((bool value) => ToggleRandomSpawngin(ui_toggle_nodes.isOn));
        #endregion LISTENERS

        panel_GameOver.SetActive(false);
    }

    public void ToggleNodes(bool isVisible) {
        manager.SetNodeVisibility(isVisible);
    }

    public void ToggleRandomSpawngin(bool i_isControlledSpawnActivated) {
        minionSpawner.isControlledSpawnActivated = i_isControlledSpawnActivated;
        minionSpawner.isControlledSpawnActivated = true;
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

    public void UpdateEventLog_Takingdamage() {
        string temp = text_eventScrollData.text;
        text_eventScrollData.text = temp + System.Environment.NewLine + "minion taking damage";
    }

    public void UpdateAIBaseHealth_value(float iValue) {
        Debug.Log(iValue);
        if(iValue == 0) {
            Enable_panel_GameOver();
            Debug.Log("ok! done");
        }
        text_AIBaseHealth_value.text = iValue.ToString();
    }

    private void OnClick_Quit() {
        Application.Quit();
    }

    private void Enable_panel_GameOver() {
        panel_GameOver.SetActive(true);
    }

    public void Display_Unit_Test_1_Result(string iResult) {
        text_test_result_1.text = iResult;
    }

    public void Display_Unit_Test_2_Result(string iResult) {
        text_test_result_2.text = iResult;
    }

    public void Display_Unit_Test_3_Result(string iResult) {
        text_test_result_3.text = iResult;
    }
}
