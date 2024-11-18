using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathField : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject deathCamera;
    public GameObject cutsceneCamera;
    public GameObject minimap;
    public GameObject mainUI;

    void OnTriggerEnter(Collider other)
    {
		if(other.tag == "bugBot") {
			return;
		} else {
			if(playerCamera.gameObject.activeInHierarchy == true) {
            	deathCamera.transform.position = playerCamera.transform.position;
            	playerCamera.gameObject.SetActive(false);
        	} else if(cutsceneCamera.gameObject.activeInHierarchy == true) {
            	deathCamera.transform.position = cutsceneCamera.transform.position;
            	cutsceneCamera.gameObject.SetActive(false);
        	}
        
        	Cursor.lockState = CursorLockMode.None;
        	minimap.gameObject.SetActive(false);
        	mainUI.gameObject.SetActive(false);
        	Debug.Log("Player has Died");
        	Time.timeScale = 0;
        	Cursor.visible = true;
        	Cursor.lockState = CursorLockMode.None;

        	deathCamera.gameObject.SetActive(true);
		}
    }
}