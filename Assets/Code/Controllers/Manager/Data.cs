using System;

[Serializable]
public class Data
{
    public string currentLevel;
    public string previousLevel;
    public float[] playerLocation;
    public int health;
    public int hintLog;

    public Data(Player playerObject)
    {
        playerLocation = new float[3];
        if (playerObject != null)
        {
            playerLocation[0] = playerObject.gameObject.transform.position.x;
            playerLocation[1] = playerObject.gameObject.transform.position.y;
            playerLocation[2] = playerObject.gameObject.transform.position.z;
        }
        else
        {
            playerLocation[0] = 0;
            playerLocation[1] = 0;
            playerLocation[2] = 0;
        }

        currentLevel = playerObject.currentLevel;
        previousLevel = playerObject.previousLevel;
        health = playerObject.health;
        hintLog = playerObject.hints;
    }
}
