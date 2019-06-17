using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private bool entered;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && entered)
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        entered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        entered = false;
    }
}


