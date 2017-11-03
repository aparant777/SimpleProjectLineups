using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

    public Button button_LoadGame;
    public Button button_Quit;
    public Button button_Options;
	public Button button_LoadSavedGamesPanel;
	public Button button_LoadSavedGame1;
	public Button button_LoadSavedGame2;
	public Button button_LoadSavedGame3;
	public Button button_BackToMainMenu;

	public GameObject fadedPanel;
	public GameObject panel_LoadGames;

    void Start () {

        button_LoadGame = GameObject.Find("Canvas/Panel/Panel/Button-New GAme").GetComponent<Button>();
        button_Quit = GameObject.Find("Canvas/Panel/Panel/Button-Quit").GetComponent<Button>();
        button_Options = GameObject.Find("Canvas/Panel/Panel/Button-Options").GetComponent<Button>();
		button_LoadSavedGame1 = GameObject.Find ("Canvas/Panel/Panel_Load/Button-New GAme (1)").GetComponent<Button> ();
		button_LoadSavedGame2 = GameObject.Find ("Canvas/Panel/Panel_Load/Button-New GAme (2)").GetComponent<Button> ();
		button_LoadSavedGame3 = GameObject.Find ("Canvas/Panel/Panel_Load/Button-New GAme (3)").GetComponent<Button> ();
		button_LoadSavedGamesPanel = GameObject.Find ("Canvas/Panel/Panel/Button-Load Game").GetComponent<Button> ();
		button_BackToMainMenu = GameObject.Find ("Canvas/Panel/Panel_Load//Canvas/Panel/Panel_Load/Button-BackToMenu").GetComponent<Button> ();

		fadedPanel = GameObject.Find("Canvas/Panel-ScreenFader");
		panel_LoadGames = GameObject.Find ("Canvas/Panel/Panel_Load");

        button_LoadGame.onClick.AddListener(() => LoadGame());
        button_Quit.onClick.AddListener(() => Quit());
        button_Options.onClick.AddListener(() => LoadOptions());
		button_BackToMainMenu.onClick.AddListener (() => BackToMainMenu ());
		button_LoadSavedGamesPanel.onClick.AddListener (() => OpenLoadGamesPlanel ());
		button_LoadSavedGame1.onClick.AddListener (() => LoadSavedGame ());
        fadedPanel.SetActive(false);
		panel_LoadGames.SetActive (false);
    }
	
    public void Quit() {
        FadePanel();
        Invoke("InvokedChaged_Quit", 1.5f);
    }

    public void LoadGame() {
        FadePanel();
		PlayerPrefs.SetString ("wasGameSaved", "no");
        Invoke("InvokedChaged_Game", 1.5f);
    }

    public void LoadOptions() {
        FadePanel();
        Invoke("InvokedChaged_Options", 1.5f);
    }

    public void FadePanel() {
        fadedPanel.SetActive(true);      
    }

    public void InvokedChaged_Game() {
        Application.LoadLevel("Loading");
    }

    public void InvokedChaged_Options() {
        Application.LoadLevel("Options");
    }

    public void InvokedChaged_Quit() {
        Application.Quit(); 
    }

	public void OpenLoadGamesPlanel(){
		panel_LoadGames.SetActive (true);
	}

	public void BackToMainMenu(){	
		panel_LoadGames.SetActive (false);
	}

	public void LoadSavedGame(){
		PlayerPrefs.SetString ("wasGameSaved", "yes");
		InvokedChaged_Game ();
	}
}
