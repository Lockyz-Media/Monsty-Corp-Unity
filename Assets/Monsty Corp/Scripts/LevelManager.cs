using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DialogueEditor;
using IngameDebugConsole;
 
 public class LevelManager : MonoBehaviour {

    [Header ("Pause Manager") ]
    public GameObject pauseCanvas;
    public GameObject mainUI;
    public GameObject minimap;
    
    [Header ("Steam Manager") ]
    public long steamID = 1335580;
    public string steamState = "";
    public string steamDetails = "";

    [Header ("Settings Manager")]
    public GameObject audioGUI;
    public GameObject displayGUI;
    public GameObject settingsGUI;

	[Header ("Game Stuffs")]
	public bool isPaused = false;
	public bool isCheats;
	public bool isLogWindowVisible = false;

    [Header ("Misc Stuff") ]
    public string baseSceneName = "Scene1";
    public bool isUITrue = false;
    public bool isCameraLock = false;
    public GameObject deathCamera;
    public GameObject playerCamera;
    public GameObject cutsceneCamera;
    public GameObject debugMenu;
	public failCounter failCounter;
	public saveSystem saveSystem;
	public sceneTwo sceneTwo;

	// Use this for initialization
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        if(isUITrue == true) {
            //Minimap is currently unfinished and cannot be enabled just yet
            //minimap.gameObject.SetActive(true);
            mainUI.gameObject.SetActive(true);
        }
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Scene1") {
            Debug.Log("Scene 1 Loaded checking if has completed game");
        }

		DebugLogConsole.AddCommand( "scene_menu", "Opens the Main Menu", scene_mainMenu );
		DebugLogConsole.AddCommand( "scene_level_one", "Opens Level One", scene_levelOne );
		DebugLogConsole.AddCommand( "scene_level_two", "Opens Level Two", scene_levelTwo );
		DebugLogConsole.AddCommand( "scene_level_three", "Opens Level Two", scene_mainMenu );
		DebugLogConsole.AddCommand( "scene_DLC_prequels", "Opens the Prequels DLC", scene_prequelsDLC );
		DebugLogConsole.AddCommand( "scene_DLC_sequels", "Opens the Sequels DLC", scene_sequelsDLC );
		DebugLogConsole.AddCommand( "scene_test", "Opens the Test Scene", scene_testScene );
		DebugLogConsole.AddCommand( "restart", "Restarts the level", restart );
		DebugLogConsole.AddCommand( "enable_UI", "Enables the main UI", enableUI );
		DebugLogConsole.AddCommand( "reset_save", "Resets your current save file and restarts the game", resetSave );
		DebugLogConsole.AddCommand( "llama", "Llama", llama );
		DebugLogConsole.AddCommand( "trigger_death", "Kills the Player", playerDeath );
		DebugLogConsole.AddCommand( "trigger_cameraFlip", "Flips the Camera", flipCamera );
		if(scene.name == "Scene2") {
			DebugLogConsole.AddCommand( "trigger_fail", "Runs the Failed 5 times trigger", triggerFail );
			DebugLogConsole.AddCommand( "cutscene_one", "Runs the First Cutscene", cutscene_one );
			DebugLogConsole.AddCommand( "cutscene_two", "Runs the Second Cutscene", cutscene_two );
			DebugLogConsole.AddCommand( "cutscene_three", "Runs the Third Cutscene", cutscene_three );
		}
	}

	void Update () {
		if(isPaused) {
			if(Input.GetButtonDown("Console")) {
				if( isLogWindowVisible ) {
					FindObjectOfType<IngameDebugConsole.DebugLogManager>().HideLogWindow();
					isLogWindowVisible = false;
				} else {
					FindObjectOfType<IngameDebugConsole.DebugLogManager>().ShowLogWindow();
					isLogWindowVisible = true;
				}
			}
		}
	}

	public void cutscene_one() {
		sceneTwo.cutsceneOne();
	}

	public void cutscene_two() {
		sceneTwo.cutsceneTwo();
	}

	public void cutscene_three() {
		sceneTwo.cutsceneThree();
	}

	public void llama() {
		Debug.Log("Llama");
	}

	public void paused() {
		isPaused = true;
	}

	public void unPaused() {
		isPaused = false;
	}

	public void flipCamera() {
        playerCamera.transform.Rotate(0, 0*Time.deltaTime, 180);
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

	public void resetSave() {
		saveSystem.ResetData();
	}

	public void triggerFail() {
		failCounter.triggerFail();
	}

    public void scene_mainMenu() {
        Debug.Log("Main Menu");
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

	public void scene_levelOne() {
        Debug.Log("Scene1");
        SceneManager.LoadScene("Scene1");
        Time.timeScale = 1;
    }

    public void scene_levelTwo() {
        Debug.Log("Scene2");
        SceneManager.LoadScene("Scene2");
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
    }

    public void quitGame()
    {
    	Application.Quit();
    }

    public void playerDeath() {
        if(playerCamera.gameObject.activeInHierarchy == true) {
            deathCamera.transform.position = playerCamera.transform.position;
            playerCamera.gameObject.SetActive(false);
        } else if(cutsceneCamera.gameObject.activeInHierarchy == true) {
            deathCamera.transform.position = cutsceneCamera.transform.position;
            cutsceneCamera.gameObject.SetActive(false);
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
 }