using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    public void OpenItems()
    {
        animator.SetBool("IsOpen", true);
        nameText.text = PersistenceManager.manager.characterName + ": items and score";

        dialogueText.text = "Lives: " + PersistenceManager.manager.health;
        dialogueText.text += Environment.NewLine + "Points: " + PersistenceManager.manager.characterPoints;
        dialogueText.text += Environment.NewLine + "Hints: " + PersistenceManager.manager.hints;
        dialogueText.text += Environment.NewLine + "Potion: " + "0";
    }

    public void CloseItems()
    {
        animator.SetBool("IsOpen", false);
    }
}
