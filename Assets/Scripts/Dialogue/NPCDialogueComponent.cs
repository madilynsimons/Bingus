using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueComponent : MonoBehaviour
{
    public bool Next { get; set; }
    
    public DialoguePageVM[] DialoguePages = new[]
    {
        new DialoguePageVM("Bella", "How old are you?"),
        new DialoguePageVM("Edward", "Seventeen"),
        new DialoguePageVM("Bella", "How long have you been seventeen?"),
        new DialoguePageVM("Edward", "A while."),
    };
}
