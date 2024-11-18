using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class saveSystem : MonoBehaviour {

    [Header ("Main Stuff") ]
    public int checkpoint;
    public int scene;
    [Header ("Main Menu Stuff") ]
    public GameObject betaGUI;
    public GameObject titleText;
    public GameObject mainMenu;
	public int checkpointID;
    public int sceneID;
    public bool hasConfirmBeta;
    bool isDeveloper;
    bool isTester;
    bool cheatsEnabled;
    int playerSpeed;
    int playerStrength;
    int playerHealth;
    int hackSkill;
    int quantumFound;
    int deathCount;
    int killCount;

	void Start() {
        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
        LoadGame();
        if(sceneName == "Main Menu") {
            if(hasConfirmBeta == true) {
                betaGUI.gameObject.SetActive(false);
                titleText.gameObject.SetActive(true);
                mainMenu.gameObject.SetActive(true);
            }
        }
        if(sceneName == "Scene1") {
            if(checkpointID == 0) {
                checkpointID = 1;
                sceneID = 0;
                SaveGame();
            }
        }
	}

    public void mainLoad() {
        if(sceneID == 0) {
            SceneManager.LoadScene("Scene1");
        } else if(sceneID == 1) {
            SceneManager.LoadScene("Scene2");
        } else {
            SceneManager.LoadScene("Scene1");
        }
    }

    public void newCheckpoint(int newCheckPoint, int newScene) {
        checkpointID = newCheckPoint;
        sceneID = newScene;
        SaveGame();
    }

    public void agreeTerms() {
        hasConfirmBeta = true;
        SaveGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter(); 
	    FileStream file = File.Create(Application.persistentDataPath 
            + "/MonstyCorp.save"); 
	    SaveData data = new SaveData();
	    data.savedCheckpointID = checkpointID;
        data.savedSceneID = sceneID;
        data.savedHasConfirmBeta = hasConfirmBeta;
	    bf.Serialize(file, data);
    	file.Close();
	    Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath 
            + "/MonstyCorp.save"))
	    {
		    BinaryFormatter bf = new BinaryFormatter();
		    FileStream file = 
                File.Open(Application.persistentDataPath 
                + "/MonstyCorp.save", FileMode.Open);
		    SaveData data = (SaveData)bf.Deserialize(file);
		    file.Close();
		    checkpointID = data.savedCheckpointID;
            sceneID = data.savedSceneID;
            hasConfirmBeta = data.savedHasConfirmBeta;
            isDeveloper = data.savedIsDeveloper;
            isTester = data.savedIsTester;
            cheatsEnabled = data.savedCheatsEnabled;
            playerSpeed = data.savedPlayerSpeed;
            playerStrength = data.savedPlayerStrength;
            playerHealth = data.savedPlayerHealth;
            hackSkill = data.savedHackSkill;
            quantumFound = data.savedQuantumFound;
            deathCount = data.savedDeathCount;
            killCount = data.savedKillCount;
		    Debug.Log("Game data loaded!");
        }
	    else {
            Debug.LogError("There is no save data!");
            BinaryFormatter bf = new BinaryFormatter(); 
	        FileStream file = File.Create(Application.persistentDataPath 
                + "/MonstyCorp.save"); 
            checkpointID = 0;
            sceneID = 0;
            SaveGame();
        }
    }

    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath 
            + "/MonstyCorp.save"))
	    {
	        File.Delete(Application.persistentDataPath 
                + "/MonstyCorp.save");
		    checkpointID = 0;
            sceneID = 0;
            isDeveloper = false;
            isTester = true;
            cheatsEnabled = false;
            playerSpeed = 5;
            playerStrength = 0;
            playerHealth = 100;
            hackSkill = 0;
            quantumFound = 0;
            deathCount = 0;
            killCount = 0;
		    Debug.Log("Data reset complete!");
	    }
	    else
		    Debug.LogError("No save data to delete.");
    }
}

[Serializable]
class SaveData {
	public int savedCheckpointID;
    public int savedSceneID;
    public bool savedHasConfirmBeta;
    public bool savedIsDeveloper;
    public bool savedIsTester;
    public bool savedCheatsEnabled;
    public int savedPlayerSpeed;
    public int savedPlayerStrength;
    public int savedPlayerHealth;
    public int savedHackSkill;
    public int savedQuantumFound;
    public int savedDeathCount;
    public int savedKillCount;
}