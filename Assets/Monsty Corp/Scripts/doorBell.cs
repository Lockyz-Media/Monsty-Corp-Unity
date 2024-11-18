using UnityEngine;

public class doorBell : MonoBehaviour
{

    public AudioClip bellSound;
    public GameObject uiElement;

    bool enter = false;

    void Start () {
        GetComponent<AudioSource> ().playOnAwake = false;
        GetComponent<AudioSource> ().clip = bellSound;
    }

    // Main function
    void Update()
    {
        if (Input.GetButtonDown("interact") && enter)
        {
            GetComponent<AudioSource> ().Play();
        }
    }
    
    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement.gameObject.SetActive(true);
            enter = true;
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement.gameObject.SetActive(false);
            enter = false;
        }
    }
}