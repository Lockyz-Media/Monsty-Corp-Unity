using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DialogueEditor;

public class debugMenu : MonoBehaviour {

    [Header ("Menus") ]
    public GameObject debug;
    public GameObject pauseCanvas;
    public GameObject mainUI;
    public GameObject minimap;
    public GameObject audioGUI;
    public GameObject displayGUI;
    public GameObject settingsGUI;
    public GameObject camura;
    [Header ("Others")]
    public LevelManager levelManager;


    void Update() {
        if(Input.GetButtonDown("CheatButton")) {
            //levelManager.debugMenu();
        }
    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }

    public void flipCamera() {
        camura.transform.Rotate(0, 0*Time.deltaTime, 180);
	}

    /*public void scene_levelOne() {
        Debug.Log("Scene1");
        SceneManager.LoadScene("Scene1");
        Time.timeScale = 1;
    }

    public void scene_levelTwo() {
        Debug.Log("Scene2");
        SceneManager.LoadScene("Scene2");
        Time.timeScale = 1;
    }

    public void scene_mainMenu() {
        Debug.Log("Main Menu");
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void scene_openCredits() {
        Debug.Log("Opening Credits");
        SceneManager.LoadScene("Opening Credits");
        Time.timeScale = 1;
    }

    public void scene_prequelsDLC() {
        Debug.Log("The Prequels");
        SceneManager.LoadScene("The Prequels");
        Time.timeScale = 1;
    }

    public void scene_testScene() {
        Debug.Log("testScene");
        SceneManager.LoadScene("testScene");
        Time.timeScale = 1;
    }

    public void scene_sequelsDLC() {
        Debug.Log("sequelsDLC");
        SceneManager.LoadScene("sequelsDLC");
        Time.timeScale = 1;
    }*/

} 