using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }

} 