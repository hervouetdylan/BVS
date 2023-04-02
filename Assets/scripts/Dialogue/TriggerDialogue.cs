using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{

    public Dialogue dialogue;

    // Start is called before the first frame update
    public void DialogueTrigger()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
