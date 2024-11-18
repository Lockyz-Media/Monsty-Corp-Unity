using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class failCounter : MonoBehaviour
{
    public GameObject failCondition;
    public GameObject failText;
    public GameObject textToDisable;
    public GameObject checkpointToDisable;
    public GameObject thisObject;
    public GameObject failCounterP2;
    public float failCount = 0f;
    public float failTriggCount = 5f;

    void OnTriggerEnter(Collider other)
    {
        if(failCount > failTriggCount) {
            triggerFail();
        } else {
            failCount++;
            thisObject.gameObject.SetActive(false);
        }
    }

    public void triggerFail() {
        failCondition.gameObject.SetActive(true);
        textToDisable.gameObject.SetActive(false);
        failText.gameObject.SetActive(true);
        failCounterP2.gameObject.SetActive(false);
    }
}