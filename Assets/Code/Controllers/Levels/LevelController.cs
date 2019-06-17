using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    void Start()
    {
        setScenes();
    }

    void setScenes()
    {
        if (PersistenceManager.manager.currentScene != null)
        {
            PersistenceManager.manager.previousScene = PersistenceManager.manager.currentScene;
        }
        else
        {
            PersistenceManager.manager.previousScene = "StageSelection";
        }
        PersistenceManager.manager.currentScene = SceneManager.GetActiveScene().name;
    }
}
