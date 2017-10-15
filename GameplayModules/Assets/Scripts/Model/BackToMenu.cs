using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour {
    public Button backToMainMenu;

    public void Start() {
        backToMainMenu = GameObject.Find("Canvas/Button-Back").GetComponent<Button>();
        backToMainMenu.onClick.AddListener(() => BackToMainMenu());
    }

    public void BackToMainMenu() {
        Application.LoadLevel("MainMenu");
    }

}
