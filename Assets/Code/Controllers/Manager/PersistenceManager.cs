using Assets.Code.Models.Game;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager manager = null;
    public List<Question> allQuestions;

    public Material stage01Bg;
    public Material stage02Bg;
    public Material stage03Bg;

    private Player player = new Player();

    public int health { get; set; } = 4;
    public string characterName { get; set; }
    public int characterPoints { get; set; }
    public string currentScene { get; set; }
    public string previousScene { get; set; }
    public List<Stage> stages { get; set; }
    public int stageIdentifier { get; set; }
    public int hints { get; set; } = 0;
    public int questionCounter { get; set; }
    public float countdownTimer { get; set; }
    public bool gamePractice { get; set; } = false;

    public void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentScene = "TitleScreen";
        hints = 0;
        allQuestions = Save.LoadQuestions();
        getSavedData();
        stages = generateStagesForGame(3);
	}


	public Material returnBgMaterial(int stageId)
    {
        Material returnMaterial = null;

        switch (stageId)
        {
            case 0:
                returnMaterial = stage01Bg;
                break;
            case 1:
                returnMaterial = stage02Bg;
                break;
            case 2:
                returnMaterial = stage03Bg;
                break;
        }

        return returnMaterial;
    }


    private List<Question> setBossChallengeQuestions(int bossNr)
    {
        List<Question> questions = new List<Question>();
        foreach (Question q in allQuestions)
        {
            if (!q.inChallenge && questions.Count < 5)
            {
                q.inChallenge = true;
                questions.Add(q);
            }
        }
        return questions;
    }


    private Challenge generateChallengeForBoss(int challengeNr)
    {
        string challengeTitle = "CHALLENGE " + challengeNr;
        Challenge c = new Challenge(challengeNr, challengeTitle, "None", setBossChallengeQuestions(challengeNr));
        return c;
    }


    private Boss generateBossForStage(int bossNr)
    {
        Boss b = new Boss(1, 5, 10, "DRAGON BOSS", "None");
        b.setChallenge(generateChallengeForBoss(bossNr));
        return b;
    }


    private List<Stage> generateStagesForGame(int amount)
    {
        List<Stage> stages = new List<Stage>();
        for (int i = 0; i <= amount; i++)
        {
            Stage s = new Stage(i, generateBossForStage(i));
            stages.Add(s);
        }
        return stages;
    }


    private void getSavedData()
    {
        if (!Save.DoesFileExist("stage.yeet"))
        {
            Save.SaveStage(stages);
        }

        if (!Save.DoesFileExist("player.genk"))
        {
            player.health = health;
            player.previousLevel = "";
            player.currentLevel = "Plains";
            player.hints = 0;
            Save.SavePlayer(player);
        }

        if (!Save.DoesFileExist("hints.dank"))
        {
            Save.SaveHints(player.hints);
        }
    }


	private List<Tip> generateTips(string first, string second, string third)
	{
		List<Tip> tips = new List<Tip>();
		Tip tip = new Tip(first);
		Tip secondTip = new Tip(second);
		Tip thirdTip = new Tip(third);

		tips.Add(tip);
		tips.Add(secondTip);
		tips.Add(thirdTip);

		return tips;
	}
}