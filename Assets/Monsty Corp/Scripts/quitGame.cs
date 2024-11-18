using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
 public class quitGame : MonoBehaviour {
     void Start() {
        Application.Quit();
     }

     void Update() {
        Application.Quit();
        //SceneManager.LoadScene("Main Menu");
     }
 }