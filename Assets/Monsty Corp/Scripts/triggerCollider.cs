using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCollider : MonoBehaviour
{
    public GameObject toActivate;

    void OnTriggerEnter(Collider other)
    {
		if(other.tag == "bugBot") {
			return;
		} else {
            toActivate.gameObject.SetActive(true);
		}
    }
}