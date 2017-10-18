using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

    public Button button_LoadGame;
    public Button button_Quit;
    public Button button_Options;
    public GameObject fadedPanel;

    void Start () {

        button_LoadGame = GameObject.Find("Canvas/Panel/Panel/Button-New GAme").GetComponent<Button>();
        button_Quit = GameObject.Find("Canvas/Panel/Panel/Button-Quit").GetComponent<Button>();
        button_Options = GameObject.Find("Canvas/Panel/Panel/Button-Options").GetComponent<Button>();

        button_LoadGame.onClick.AddListener(() => LoadGame());
        button_Quit.onClick.AddListener(() => Quit());
        button_Options.onClick.AddListener(() => LoadOptions());

        fadedPanel = GameObject.Find("Canvas/Panel-ScreenFader");
        fadedPanel.SetActive(false);
    }
	
    public void Quit() {
        FadePanel();
        Invoke("InvokedChaged_Quit", 1.5f);
    }

    public void LoadGame() {
        FadePanel();
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
}
