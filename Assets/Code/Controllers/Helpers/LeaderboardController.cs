using Assets.Code.Repository;
using Assets.Code.Repository.MySQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{
    public Text characterInput;

    private ScoreRepository scoreRepo = new ScoreRepository(new ScoreMySQLContext());
    private Navigation navigation;

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Victory"))
        {
            scoreRepo.SaveCharacterPoints();
        }

        if (SceneManager.GetActiveScene().name.Equals("CharacterCreation"))
        {
            navigation = FindObjectOfType<Navigation>();
        }
    }

    private void UpdateCharacterPoints()
    {
        PersistenceManager.manager.characterPoints += 1;
    }

    public void SetCharacter()
    {
        PersistenceManager.manager.characterName = characterInput.text;
        PersistenceManager.manager.gamePractice = false;
        navigation.OpenScene("Intro");
    }

    public void SaveCharacterPoints()
    {
        scoreRepo.SaveCharacterPoints();
    }
}
