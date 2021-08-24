using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueService : MonoBehaviour
{
    private UserDialogueComponent m_userDialogueComponent;
    private NPCDialogueComponent m_npcDialogueComponent;
    private CanvasComponent m_canvasComponent;

    private int m_dialogueIterator = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        m_userDialogueComponent = GameObject.FindWithTag("Player").GetComponent<UserDialogueComponent>();
        m_npcDialogueComponent = GetComponent<NPCDialogueComponent>();
        m_canvasComponent = GameObject.FindWithTag("Canvas").GetComponent<CanvasComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InConversationWithPlayer())
        {
            if (m_npcDialogueComponent.Next)
            {
                if (m_dialogueIterator >= m_npcDialogueComponent.DialoguePages.Length)
                {
                    m_canvasComponent.CurrentDialogue = null;
                    m_userDialogueComponent.ExitConversation();
                }
                else
                {
                    m_npcDialogueComponent.Next = false;
                    m_canvasComponent.CurrentDialogue = m_npcDialogueComponent.DialoguePages[m_dialogueIterator];
                    m_dialogueIterator++;
                }
            }
        }
    }

    bool InConversationWithPlayer()
    {
        return m_userDialogueComponent.InConversation &&
               m_userDialogueComponent.ConversationBuddy == m_npcDialogueComponent;
    }
}
