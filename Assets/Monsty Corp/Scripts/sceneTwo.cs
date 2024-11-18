using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneTwo : MonoBehaviour {

    [Header ("Main Stuff") ]
    public saveSystem Other;
    public Transform checkpointThree;
    public Transform checkpointFour;
    public GameObject thePlayer;
    public GameObject firstCutscene;
    public GameObject activateCheckpoint3;
    public GameObject activateCheckpoint4;

    void Start() {
        Other.LoadGame();
        if(Other.checkpointID == 1) {
            Other.newCheckpoint(newCheckPoint: 2, newScene: 1);
        }
        if(Other.checkpointID == 3) {
            firstCutscene.gameObject.SetActive(false);
            thePlayer.transform.position = checkpointThree.transform.position;
            activateCheckpoint3.gameObject.SetActive(true);
        }
        if(Other.checkpointID == 4) {
            thePlayer.transform.position = checkpointFour.transform.position;
            firstCutscene.gameObject.SetActive(false);
            activateCheckpoint4.gameObject.SetActive(true);
        }
    }

    public void cutsceneOne() {
        Other.newCheckpoint(newCheckPoint: 2, newScene: 1);
    }

    public void cutsceneTwo() {
        firstCutscene.gameObject.SetActive(false);
        thePlayer.transform.position = checkpointThree.transform.position;
        activateCheckpoint3.gameObject.SetActive(true);
    }

    public void cutsceneThree() {
        thePlayer.transform.position = checkpointFour.transform.position;
        firstCutscene.gameObject.SetActive(false);
        activateCheckpoint4.gameObject.SetActive(true);
    }
}