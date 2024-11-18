using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public bool LoadOnStart;
    public int levelNumber;

    void Start() {
        SceneManager.LoadScene(levelNumber);
        Time.timeScale = 1;
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
} 