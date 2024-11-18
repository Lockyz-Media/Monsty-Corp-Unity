using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DialogueEditor;
 
 public class gameOpening : MonoBehaviour {

	// Use this for initialization
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Scene scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Opening Credits") {
            if(Input.GetButtonDown("Cancel")) {
                SceneManager.LoadScene("Main Menu");
            }
        }
	}
 }