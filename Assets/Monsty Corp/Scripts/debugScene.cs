using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Steamworks;
using Discord;
using DialogueEditor;

public class debugScene : MonoBehaviour {

    [Header ("Menus") ]
    public GameObject debug;
    public GameObject pauseCanvas;
    public GameObject mainUI;
    public GameObject minimap;
    public GameObject audioGUI;
    public GameObject displayGUI;
    public GameObject settingsGUI;

    [Header ("Teleports") ]
    public Transform hackProtoTP;
    public Transform skillsProtoTP;
    public Transform enemyAIProtoTP;
    public Transform minimapProtoTP;
    public Transform quantumProtoTP;

    [Header ("Misc") ]
    public GameObject thePlayer;
    public GameObject deathCamera;
    public bool isUITrue = false;
    public bool isCameraLock = false;

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCameraLock = true;
        debug.gameObject.SetActive(true);
        Time.timeScale = 1;
        if(isUITrue == true) {
            mainUI.gameObject.SetActive(true);
        }
    }

    void Update() {
        Scene scene = SceneManager.GetActiveScene();
        if(Input.GetButtonDown("CheatButton")) {
            if(debug.gameObject.activeInHierarchy == true)  {
                Time.timeScale = 1;
                Cursor.visible = false;
                debug.gameObject.SetActive(false);
                return;
            } else if(debug.gameObject.activeInHierarchy == false) {
                Cursor.lockState = CursorLockMode.None;
                debug.gameObject.SetActive(true);
                pauseCanvas.gameObject.SetActive(false);
                settingsGUI.gameObject.SetActive(false);
                audioGUI.gameObject.SetActive(false);
                displayGUI.gameObject.SetActive(true);
                mainUI.gameObject.SetActive(false);
                Time.timeScale = 0;
                Cursor.visible = true;
                isCameraLock = true;
                return;
            }
        }
    }

    public void enableUI() {
        mainUI.gameObject.SetActive(true);
        isUITrue = true;
    }

    public void restart() {
        Debug.Log("Restarted");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void playerDeath() {
        if(thePlayer.gameObject.activeInHierarchy == true) {
            deathCamera.transform.position = thePlayer.transform.position;
            thePlayer.gameObject.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.None;
        minimap.gameObject.SetActive(false);
        mainUI.gameObject.SetActive(false);
        Debug.Log("Player has Died");
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        deathCamera.gameObject.SetActive(true);
    }

    public void loadScene(string SceneName) {
        Debug.Log("Loading "+SceneName);
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1;
    }
    
    public void tp_hackProto() {
        thePlayer.transform.position = hackProtoTP.transform.position;
        Time.timeScale = 1;
        Cursor.visible = false;
        debug.gameObject.SetActive(false);
        Debug.Log("Teleporting player to Hack Prototype");
    }

    public void tp_quantumProto() {
        thePlayer.transform.position = quantumProtoTP.transform.position;
        Time.timeScale = 1;
        Cursor.visible = false;
        debug.gameObject.SetActive(false);
        Debug.Log("Teleporting player to Hack Prototype");
    }

    public void tp_skillProto() {
        thePlayer.transform.position = skillsProtoTP.transform.position;
        Time.timeScale = 1;
        Cursor.visible = false;
        debug.gameObject.SetActive(false);
        Debug.Log("Teleporting Player to Skills Prototype");
    }

    public void tp_enemyAIProto() {
        thePlayer.transform.position = enemyAIProtoTP.transform.position;
        Time.timeScale = 1;
        Cursor.visible = false;
        debug.gameObject.SetActive(false);
        Debug.Log("Teleporting Player to Enemy AI Prototype");
    }

    public void tp_minimapProto() {
        thePlayer.transform.position = minimapProtoTP.transform.position;
        Time.timeScale = 1;
        Cursor.visible = false;
        debug.gameObject.SetActive(false);
        Debug.Log("Teleporting Player to Minimap Prototype");
    }

} 