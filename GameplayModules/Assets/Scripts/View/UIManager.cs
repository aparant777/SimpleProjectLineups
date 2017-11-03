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
    //public Text text_test_result_1;
    //public Text text_test_result_2;
    //public Text text_test_result_3;

    private InputField inputfield_SpawnRate;

    private Button button_SpawnRate;
    private Button button_Quit;
    private Button button_TutorialReady;
    private Button button_PauseGame;
    private Button button_ResumeGame;
    private Button button_ReplayGame;
    private Button button_BackToMainMenu;
	public Button button_QuitGame;
	public Button button_SaveGame;

    private Toggle ui_toggle_nodes;
    private Toggle ui_toggle_controlledSpawning;

    private GameObject panel_Tutorial;
    private GameObject panel_GameOver;
    private GameObject panel_PauseMenu;

    public Text ui_text_money_owned;
    public Text ui_text_money_owned_value;

    public Text ui_text_total_time_value;

    public float time;
	public SaveManager saveManager;

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

        //minionSpawner = GameObject.Find("Minion Spawner").GetComponent<MinionSpawner>();

        text_totalNumberOfMinions = GameObject.Find("Text-Total Number of Minions").GetComponent<Text>();
        text_totalNumberOfMinions_value = GameObject.Find("Text-Total Number of Minion-Value").GetComponent<Text>();
        text_eventScrollData = GameObject.Find("Content-Eventdata").GetComponent<Text>();
        //text_AIBaseHealth_value = GameObject.Find("Text_AIBaseHealth_Value").GetComponent<Text>();
        //text_test_result_1 = GameObject.Find("Text-test11").GetComponent<Text>();
        //text_test_result_2 = GameObject.Find("Text-test22").GetComponent<Text>();
        //text_test_result_3 = GameObject.Find("Text-test33").GetComponent<Text>();

        inputfield_SpawnRate = GameObject.Find("InputField-Spawn Rate").GetComponent<InputField>();

        button_Quit = GameObject.Find("Button-Quit").GetComponent<Button>();
        button_SpawnRate = GameObject.Find("Button-Spawn Rate").GetComponent<Button>();
        button_TutorialReady = GameObject.Find("Button-StartGame").GetComponent<Button>();
        button_ReplayGame = GameObject.Find("Button-ReplayGame").GetComponent<Button>();
        button_BackToMainMenu = GameObject.Find("Button-MainMenu").GetComponent<Button>();
		button_QuitGame = GameObject.Find("Button-ExitGame").GetComponent<Button>();

        ui_toggle_nodes = GameObject.Find("Toggle-ShowNodes").GetComponent<Toggle>();

        ui_toggle_controlledSpawning = GameObject.Find("Toggle-Is Controlled Spawn").GetComponent<Toggle>();

        panel_Tutorial = GameObject.Find("Panel-Tutorial");
        panel_GameOver = GameObject.Find("Panel-GameOver");
        panel_PauseMenu = GameObject.Find("Panel-Pause");

        ui_text_money_owned = GameObject.Find("Text-Total Money").GetComponent<Text>();
        ui_text_money_owned_value = GameObject.Find("Text-Total Money Value").GetComponent<Text>();
        ui_text_total_time_value = GameObject.Find("Text-Total Time Value").GetComponent<Text>();

        button_PauseGame = GameObject.Find("Button-Pause").GetComponent<Button>();
        button_ResumeGame = GameObject.Find("Button-Resume").GetComponent<Button>();
		button_SaveGame = GameObject.Find("Button-SaveGame").GetComponent<Button>();

		saveManager = GameObject.Find("_Scene").GetComponent<SaveManager>();

        #endregion REFERENCES

        #region LISTENERS
        //button_Quit.onClick.AddListener(() => OnClick_Quit());
        //button_SpawnRate.onClick.AddListener(() => SetSpawnRate());
        //ui_toggle_nodes.onValueChanged.AddListener((bool value) => ToggleNodes(ui_toggle_controlledSpawning.isOn));
        //ui_toggle_controlledSpawning.onValueChanged.AddListener((bool value) => ToggleRandomSpawngin(ui_toggle_nodes.isOn));

        button_TutorialReady.onClick.AddListener(() => TutorialDone());
        button_PauseGame.onClick.AddListener(() => PauseGame());
        button_ResumeGame.onClick.AddListener(() => ResumeGame());
        button_ReplayGame.onClick.AddListener(() => manager.SceneChange_ReplayLevel());
        button_BackToMainMenu.onClick.AddListener(() => manager.SceneChange_MainMenu());
		button_QuitGame.onClick.AddListener(() => OnClick_Quit());
		button_SaveGame.onClick.AddListener(() => Perform_Save());

        #endregion LISTENERS

        panel_GameOver.SetActive(false);
        panel_Tutorial.SetActive(true);
        panel_PauseMenu.SetActive(false);
    }

    private void Update() {
        if (manager.hasGameStarted) {
            RunTimer();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    public void RunTimer() {
        time += Time.deltaTime;

        var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        var seconds = time % 60;//Use the euclidean division for the seconds.
        var fraction = (time * 100) % 100;

        ui_text_total_time_value.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        ui_text_money_owned_value.text = manager.totalMoney.ToString();
    }

    public void TutorialDone() {
        manager.hasGameStarted = true;
        panel_Tutorial.SetActive(false);
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
            //Enable_panel_GameOver();
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
       // text_test_result_1.text = iResult;
    }

    public void Display_Unit_Test_2_Result(string iResult) {
        //text_test_result_2.text = iResult;
    }

    public void Display_Unit_Test_3_Result(string iResult) {
        //text_test_result_3.text = iResult;
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        panel_PauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        panel_PauseMenu.SetActive(false);
    }

	public void Perform_Save(){
		saveManager.Perform_Save ();
	}
}
