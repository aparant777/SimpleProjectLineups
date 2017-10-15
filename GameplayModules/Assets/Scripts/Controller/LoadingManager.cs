using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingManager : MonoBehaviour {

    public Text ui_text_loadingText;
    public GameObject fadedPanel;

    public void Start() {

        ui_text_loadingText = GameObject.Find("Canvas/Text-Loading").GetComponent<Text>();
        fadedPanel = GameObject.Find("Canvas/Panel-ScreenFader");

        fadedPanel.SetActive(false);
        StartCoroutine(StartTimer());
    }

    public void SetText(string text) {
        ui_text_loadingText.text = text;
    }

    IEnumerator StartTimer() {

        float timer = 7f;
        while (timer > 0) {                  
           yield return new WaitForSeconds(1);
            // Decrease the timer   
            timer--;
        }

        // You can call here your fail function...
        SetText("Loading complete");
        fadedPanel.SetActive(true);
        Invoke("ChangeLevel", 1.5f);
    }

    public void ChangeLevel() {
        Application.LoadLevel("Second");
    }
}