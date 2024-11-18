using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DialogueEditor;

public class pauseMenu : MonoBehaviour {

    [Header ("Pause Manager") ]
    public GameObject pauseCanvas;
    public GameObject mainUI;
    public GameObject minimap;

    [Header ("Settings Manager")]
    public GameObject audioGUI;
    public GameObject displayGUI;
    public GameObject settingsGUI;

    [Header ("Misc Stuff") ]
    public GameObject deathCamera;
    public GameObject playerCamera;
    public GameObject cutsceneCamera;
    public GameObject debugMenu;
    public bool isUITrue = false;
    public bool isMinimapTrue = false;
    public bool isCameraLock = false;
    public saveSystem saveSystem;
    public LevelManager levelManager;

    void Update () {
        Scene scene = SceneManager.GetActiveScene();
        if(deathCamera.gameObject.activeInHierarchy == false)
        {
            if (Input.GetButtonDown ("Cancel")) {
                //saveSystem.SaveGame();
                if(pauseCanvas.gameObject.activeInHierarchy == true) {
                    if(ConversationManager.Instance != null) {
                        if(ConversationManager.Instance.IsConversationActive) {
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                        } else {
                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = false;
                            isCameraLock = false;
                            if(isUITrue == true) {
                                mainUI.gameObject.SetActive(true);
                            }

                            if(isMinimapTrue == true) {
                                minimap.gameObject.SetActive(true);
                            }
                        }
                    }
                    Time.timeScale = 1;
                    pauseCanvas.gameObject.SetActive(false);
                    Debug.Log("Game Resumed");
                    levelManager.unPaused();
                } else if(settingsGUI.gameObject.activeInHierarchy == true) {
                    Debug.Log("Leaving Settings");
                    settingsGUI.gameObject.SetActive(false);
                    pauseCanvas.gameObject.SetActive(true);
                    Debug.Log("Opening Pause");
                    levelManager.paused();
                } else if(debugMenu.gameObject.activeInHierarchy == true) {
                    Debug.Log("Leaving Debug");
                    debugMenu.gameObject.SetActive(true);
                    pauseCanvas.gameObject.SetActive(true);
                    Debug.Log("Opening Pause");
                    levelManager.paused();
                } else {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    isCameraLock = true;
                    Time.timeScale = 0;
                    mainUI.gameObject.SetActive(false);
                    minimap.gameObject.SetActive(false);
                    pauseCanvas.gameObject.SetActive(true);
                    Debug.Log("Game Paused");
                    levelManager.paused();
                }
            }
        }
    }

    public void resume() {
        levelManager.unPaused();
        Debug.Log("Resumed");
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        /*if(ConversationManager.Instance != null) {
            if(ConversationManager.Instance.IsConversationActive) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else {
            if(isUITrue == true) {
                mainUI.gameObject.SetActive(true);
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        /*}
        } else {
            Debug.Log("Conversation Manager is broken");
        }*/
    }
}