using UnityEngine;

public class EToActivate : MonoBehaviour
{
    public GameObject uiElement;
    public GameObject toActivate;
    bool enter = false;

    // Main function
    void Update()
    {
        if (Input.GetButtonDown("interact") && enter)
        {
            toActivate.gameObject.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player"))
        {
            enter = true;
            uiElement.gameObject.SetActive(true);
        }
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
            uiElement.gameObject.SetActive(true);
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }
}