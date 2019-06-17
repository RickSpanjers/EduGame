using UnityEngine;

public class DialogueIntroTrigger : MonoBehaviour
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
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "rock (1)" || collision.gameObject.name == "Player_Intro")
        {
            TriggerDialogue();
            CheckSentence();
        }
    }

    void CheckSentence()
    {
        if (dialogue.sentences[0].StartsWith("What do you think"))
        {
            otherDialogue.name = "Dragon Boss";
            string[] messages = new string[1];
            messages.SetValue("Destroying the house of a weak intern.", 0);
            otherDialogue.sentences = messages;
            hasSpoken = true;
        }
    }
}
