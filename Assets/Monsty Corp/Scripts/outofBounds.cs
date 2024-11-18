using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class outofBounds : MonoBehaviour {
    public float playerX = 0f;
    public float playerY = 0f;
    public float playerZ = 0f;
    public GameObject player;
    public GameObject text;
    public float timer = 10f;
    public float timerDefault = 10f;
    public bool isTimer;
    // Update is called once per frame
    void Update()
    {
        if(isTimer) {
            if(timer > 0) {
                timer -= Time.deltaTime;
            } else {
                isTimer = false;
                timer = timerDefault;
                text.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
		//if(other.tag == "Player") {
            text.gameObject.SetActive(true);
            isTimer = true;
            timer = timerDefault;
            player.transform.position = new Vector3(playerX, playerY, playerZ);
        //}
    }
}