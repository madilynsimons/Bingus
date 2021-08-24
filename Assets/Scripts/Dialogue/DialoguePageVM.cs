using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePageVM
{
    public DialoguePageVM(string speaker, string dialogue)
    {
        Speaker = speaker;
        Dialogue = dialogue;
    }
    
    public string Speaker { get; }
    public string Dialogue { get; }
}
