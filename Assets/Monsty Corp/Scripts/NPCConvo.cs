using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCConvo : MonoBehaviour
{
    [Header ("Start of Convo") ]
    public NPCConversation Conversation;
    public ConversationManager ConvoManager;
    public GameObject triggerCollider;
    public GameObject playerCamera;
    public GameObject convoCamera;
    public GameObject consequenceUI;
    public GameObject oldObjective;
    [Header ("End of Convo") ]
    public GameObject cameraPositionAfterConvo;
    public GameObject phoneUI;
    public GameObject newObjective;
    public GameObject minimap;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player chatting with NPC");
        convoCamera.gameObject.SetActive(true);
        playerCamera.gameObject.SetActive(false);
        phoneUI.gameObject.SetActive(false);
        //minimap.gameObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        ConversationManager.Instance.StartConversation(Conversation);
        //triggerCollider.gameObject.SetActive(false);
    }

    private void Update() {
        if(ConversationManager.Instance !=null) {
            if(ConversationManager.Instance.IsConversationActive) {
                if(Input.GetButtonDown("Up")) {
                    ConversationManager.Instance.SelectPreviousOption();
                } else if(Input.GetButtonDown("Down")) {
                    ConversationManager.Instance.SelectNextOption();
                } else if(Input.GetButtonDown("Submit")) {
                    ConversationManager.Instance.PressSelectedOption();
                }
            }
        }
    }

    public void endNPCConvo() {
        Debug.Log("Player no longer chatting with NPC");
        ConversationManager.Instance.EndConversation();
        convoCamera.gameObject.SetActive(false);
        playerCamera.transform.position = cameraPositionAfterConvo.transform.position;
        playerCamera.gameObject.SetActive(true);
        oldObjective.gameObject.SetActive(false);
        newObjective.gameObject.SetActive(true);
        phoneUI.gameObject.SetActive(true);
        //minimap.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        triggerCollider.gameObject.SetActive(false);
    }

    public void actionHasConsequences() {
        Debug.Log("This action WILL have consequences");
        consequenceUI.gameObject.SetActive(true);
        StartCoroutine(consequencesCoroutine());
    }
     IEnumerator consequencesCoroutine()
    {
        yield return new WaitForSeconds (10);
        consequenceUI.gameObject.SetActive(false);
    }
}