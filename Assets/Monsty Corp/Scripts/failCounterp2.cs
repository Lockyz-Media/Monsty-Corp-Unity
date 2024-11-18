using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class failCounterp2 : MonoBehaviour
{
    public GameObject failCounter;
    
    void OnTriggerEnter(Collider other)
    {
        failCounter.gameObject.SetActive(true);
    }
}