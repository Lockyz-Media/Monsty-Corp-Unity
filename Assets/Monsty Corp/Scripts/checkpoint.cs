using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class checkpoint : MonoBehaviour {

    [Header ("Main Stuff") ]
    public int checkpointID;
    public int sceneID;
    public saveSystem Other;

    void OnTriggerEnter(Collider other) {
        Other.newCheckpoint(newCheckPoint: checkpointID, newScene: sceneID);
    }
}