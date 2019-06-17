using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public string LevelNavigation()
    {
        switch (PersistenceManager.manager.currentScene)
        {
            case "TitleScreen":
                PersistenceManager.manager.currentScene = "Plains";
                PersistenceManager.manager.stageIdentifier = 0;
                break;
            case "Plains":
                PersistenceManager.manager.currentScene = "MountainAndCave";
                PersistenceManager.manager.stageIdentifier = 1;
                break;
            case "MountainAndCave":
                PersistenceManager.manager.currentScene = "Hell";
                PersistenceManager.manager.stageIdentifier = 2;
                break;
            case "Hell":
                PersistenceManager.manager.currentScene = "Outro";
                PersistenceManager.manager.stageIdentifier = 3;
                break;
        }
        return PersistenceManager.manager.currentScene;
    }

    public void CloseApplication()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
