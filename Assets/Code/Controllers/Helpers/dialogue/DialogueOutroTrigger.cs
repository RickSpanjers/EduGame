using UnityEngine;

public class DialogueOutroTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private Dialogue otherDialogue = new Dialogue();
    private float time = 4;
    private bool hasSpoken = false;

    private void Update()
    {
        if (hasSpoken)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                TriggerOtherDialogue();
                hasSpoken = false;
            }
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerOtherDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(otherDialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player_Intro")

        {
            TriggerDialogue();
            CheckSentence();
        }

        else if (collision.gameObject.name == "DragonBoss")
        {
            TriggerDialogue();
            CheckSentence();
        }
    }

    private void CheckSentence()
    {
        if (dialogue.sentences[0].StartsWith("A raise?"))
        {
            otherDialogue.name = "Knight";
            string[] messages = new string[1];
            messages.SetValue("I'll raise you my sword!", 0);
            otherDialogue.sentences = messages;
            hasSpoken = true;
        }
    }
}
