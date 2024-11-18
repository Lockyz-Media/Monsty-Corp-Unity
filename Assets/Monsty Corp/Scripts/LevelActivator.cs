using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Steamworks;
using Discord;

public class LevelActivator : MonoBehaviour {

    public string nextLevelName;

	// Use this for initialization
    void Start()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
