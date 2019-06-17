using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    public InputField nameInput;
    public GameObject nameError;
    public Dropdown classInput;
    public Character character = new Character();

    private Navigation nav = new Navigation();
    private List<Job> classes = new List<Job>();

    void Start()
    {
        nameError.SetActive(false);
        classes.Add(new Job(1, "Knight"));
    }

    public void ConfirmCharacter()
    {
        if (ValidateInput())
        {
            PersistenceManager.manager.characterName = nameInput.text;
            nav.OpenScene("Plains");
        }
    }

    private bool ValidateInput()
    {
        nameError.SetActive(false);

        if (nameInput.text == "")
        {
            nameError.SetActive(true);
            return false;
        }

        return true;
    }
}
