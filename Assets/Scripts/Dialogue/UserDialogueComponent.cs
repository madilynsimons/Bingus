using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDialogueComponent : MonoBehaviour
{
    public bool InConversation { get; private set; }
    public NPCDialogueComponent ConversationBuddy { get; private set; }

    public void EnterConversation(NPCDialogueComponent conversationBuddy)
    {
        InConversation = true;
        ConversationBuddy = conversationBuddy;
    }

    public void ExitConversation()
    {
        InConversation = false;
        ConversationBuddy = null;
    }
}
