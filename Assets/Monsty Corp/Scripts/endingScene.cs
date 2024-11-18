using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingScene : MonoBehaviour {

    public int endingNum;
    public bool isSecretEnding;
    public string endingAchievementName;
    public saveSystem saveSystem;
    bool endingComplete;
    int secretEndingStatNum;
    int endingStatNum;

    void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void mainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void quitGame() {
        Application.Quit();
    }

    public void resetGame() {
        saveSystem.ResetData();
        SceneManager.LoadScene("Scene1");
    }
} 