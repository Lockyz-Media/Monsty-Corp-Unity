using UnityEngine;

public class Door : MonoBehaviour
{

    // Smoothly open a door
    public float doorOpenAngle = 90.0f; //Set either positive or negative number to open the door inwards or outwards
    public float openSpeed = 2.0f; //Increasing this value will make the door open faster
    public GameObject uiElement;
    public GameObject lockedUi;
    public bool isLockable;
    public bool locked = false;

    bool open = false;
    bool enter = false;

    float defaultRotationAngle;
    float currentRotationAngle;
    float openTime = 0;

    void Start()
    {
        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = transform.localEulerAngles.y;
    }

    // Main function
    void Update()
    {
        if(!locked) {
            if(openTime < 1)
            {
                openTime += Time.deltaTime * openSpeed;
            }
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (open ? doorOpenAngle : 0), openTime), transform.localEulerAngles.z);

            if (Input.GetButtonDown("interact") && enter)
            {
                open = !open;
                currentRotationAngle = transform.localEulerAngles.y;
                //transform.localScale.z = 1;
                openTime = 0;
            }
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player"))
        {
            if(locked) {
                enter = true;
                lockedUi.gameObject.SetActive(true);
            } else {
                enter = true;
                uiElement.gameObject.SetActive(true);
            }
        }
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(locked) {
                enter = true;
                lockedUi.gameObject.SetActive(true);
            } else {
                enter = true;
                uiElement.gameObject.SetActive(true);
            }
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(locked) {
                enter = false;
                lockedUi.gameObject.SetActive(false);
            } else {
                enter = false;
                uiElement.gameObject.SetActive(false);
            }
        }
    }
}