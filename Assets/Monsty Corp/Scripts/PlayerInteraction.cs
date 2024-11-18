using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
 public class PlayerInteraction : MonoBehaviour {

    void Start() {

    }

    void Update() {
        InteractRaycast();
    }

    void InteractRaycast() {
        Vector3 playerPosition = transform.position;
        Vector3 forwardDirection = transform.forward;

        Ray interactionRay = new Ray(playerPosition, forwardDirection);
        RaycastHit interactionRayHit;
        float interactionRayLength = 5.0f;

        Vector3 interactionRayEndpoint = forwardDirection * interactionRayLength;
        Debug.DrawLine(playerPosition, interactionRayEndpoint);

        bool hitFound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength);

        if(hitFound) {
            GameObject hitGameobject = interactionRayHit.transform.gameObject;
            string hitFeedback = hitGameobject.name;
            Debug.Log(hitFeedback);
        } else {
            string nothingHitFeedback = "-";
            Debug.Log(nothingHitFeedback);
        }
    }
 }