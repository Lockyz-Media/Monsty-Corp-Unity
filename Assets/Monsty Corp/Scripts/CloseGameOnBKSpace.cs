using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGameOnBKSpace : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            //Application.Quit();
            SceneManager.LoadScene("Main Menu");
        }
    }
}
