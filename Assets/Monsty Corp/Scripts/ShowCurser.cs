using UnityEngine;
using System.Collections;

public class ShowCurser : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}