using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class UserDialogueService : MonoBehaviour
{
    private UserDialogueComponent m_dialogueComponent;
    private CanvasComponent m_canvasComponent;

    void Start()
    {
        m_dialogueComponent = GetComponent<UserDialogueComponent>();
        m_canvasComponent = GameObject.FindWithTag("Canvas").GetComponent<CanvasComponent>();
    }

    private void Update()
    {
        if (m_dialogueComponent.InConversation && Input.GetKeyUp(KeyCode.Z))
        {
            m_dialogueComponent.ConversationBuddy.Next = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out NPCDialogueComponent conversationBuddy))
        {
            Debug.Log("Entering conversation");
            m_dialogueComponent.EnterConversation(conversationBuddy);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (InConversationWith(other))
        {
            m_dialogueComponent.ExitConversation();
            m_canvasComponent.CurrentDialogue = null;
        }
    }

    private bool InConversationWith(Collision other)
    {
        return m_dialogueComponent.InConversation
               && other.gameObject.TryGetComponent(out NPCDialogueComponent otherDialogueComponent)
               && otherDialogueComponent == m_dialogueComponent.ConversationBuddy;
    }
}
