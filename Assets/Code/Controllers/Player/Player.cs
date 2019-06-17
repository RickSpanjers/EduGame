using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string currentLevel;
    public string previousLevel;
    public int health;
    public int hints;

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        if (currentLevel == "Plains")
        {
            previousLevel = "";
        }
        Save.SavePlayer(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Data data = Save.LoadPlayerData();
            gameObject.transform.position = new Vector3(data.playerLocation[0], data.playerLocation[1], data.playerLocation[2]);
        }
    }
}
