using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class Save
{

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.genk";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        Data data = new Data(player);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static void SaveStage(List<Stage> stages)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/stage.yeet";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, stages);
        fileStream.Close();
    }

    public static void SaveHints(int number)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/hints.dank";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, number);
        fileStream.Close();
    }

    public static void SaveQuestions(List<Question> questions)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/questions.edugame";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, questions);
        fileStream.Close();
    }

    public static void SaveControls(Dictionary<string, KeyCode> keys)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/keys.edugame";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, keys);
        fileStream.Close();
    }

    public static Data LoadPlayerData()
    {
        Data data = null;
        string path = Application.persistentDataPath + "/player.genk";

        if (DoesFileExist("player.genk"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            data = (Data)formatter.Deserialize(fileStream);
            fileStream.Close();
        }
        return data;
    }

    public static int LoadHintData()
    {
        int amount = -1;
        string path = Application.persistentDataPath + "/hints.dank";

        if (DoesFileExist("hints.dank"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            amount = (int)formatter.Deserialize(fileStream);
            fileStream.Close();
        }
        return amount;
    }

    public static List<Stage> LoadStages()
    {
        List<Stage> stages = new List<Stage>();
        string path = Application.persistentDataPath + "/stage.yeet";

        if (DoesFileExist("stage.yeet"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            stages = (List<Stage>)formatter.Deserialize(fileStream);
            fileStream.Close();
        }
        return stages;
    }

    public static List<Question> LoadQuestions()
    {
        List<Question> questions = new List<Question>();
        string path = Application.persistentDataPath + "/questions.edugame";

        if (DoesFileExist("questions.edugame"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            questions = (List<Question>)formatter.Deserialize(fileStream);
            fileStream.Close();
        }

		foreach(Question q in questions)
		{
			if(q.id == 1)
			{
				q.answer = "370";
			}
		}

		SaveQuestions(questions);
        return questions;
    }

    public static Dictionary<string, KeyCode> LoadKeys()
    {
        Dictionary<string, KeyCode> keycodes = new Dictionary<string, KeyCode>();
        string path = Application.persistentDataPath + "/keys.edugame";

        if (DoesFileExist("keys.edugame"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            keycodes = (Dictionary<string, KeyCode>)formatter.Deserialize(fileStream);
            fileStream.Close();
        }
        return keycodes;
    }

    public static bool DoesFileExist(string fileName)
    {
        bool doesExist = false;
        string path = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(path))
        {
            doesExist = true;
        }
        return doesExist;
    }
}