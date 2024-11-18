using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneOnCollide : MonoBehaviour
{
     public string level;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(level);
    }
}