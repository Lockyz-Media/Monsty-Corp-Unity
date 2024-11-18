using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
 public class quantumObject : MonoBehaviour {

    public GameObject camera;
    public GameObject target;
    int counter = 0;

    void Start() {

    }

    void Update() {
        InteractRaycast();
    }

    void InteractRaycast() {
        Vector3 playerPosition = camera.gameObject.transform.position;
        Vector3 forwardDirection = camera.gameObject.transform.forward;

        Ray interactionRay = new Ray(playerPosition, forwardDirection);
        RaycastHit interactionRayHit;
        float interactionRayLength = 5.0f;

        Vector3 interactionRayEndpoint = forwardDirection * interactionRayLength;
        Debug.DrawLine(playerPosition, interactionRayEndpoint);

        bool hitFound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength);

        if(hitFound) {
            GameObject hitGameobject = interactionRayHit.transform.gameObject;

            if(hitGameobject == gameObject) {
                string hitFeedback = hitGameobject.name;
                Debug.Log(hitFeedback);
                counter = 1;

                Debug.Log(counter);
            }
        } else {
            if(counter == 1) {
                gameObject.SetActive(false);
            }
        }
    }
 }