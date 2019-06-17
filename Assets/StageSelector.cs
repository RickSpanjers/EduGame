using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour
{
    public string levelname;
    public int questionStart;
    public string previousLevelSet;

    private Navigation navigation = new Navigation();

    void OnTriggerEnter2D(Collider2D collision)
    {
        PersistenceManager.manager.questionCounter = questionStart;
        PersistenceManager.manager.gamePractice = true;
        setStageIdentifier();
        navigation.OpenScene(levelname);
    }

    private void setStageIdentifier()
    {
        switch (levelname)
        {
            case "TitleScreen":
                PersistenceManager.manager.currentScene = levelname;
                PersistenceManager.manager.stageIdentifier = 0;
                break;
            case "Plains":
                PersistenceManager.manager.currentScene = levelname;
                PersistenceManager.manager.stageIdentifier = 0;
                break;
            case "MountainAndCave":
                PersistenceManager.manager.currentScene = levelname;
                PersistenceManager.manager.stageIdentifier = 1;
                break;
            case "Hell":
                PersistenceManager.manager.currentScene = levelname;
                PersistenceManager.manager.stageIdentifier = 2;
                break;
        }
    }

}
