using Assets.Code.Models.Game;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CombatController : MonoBehaviour
{
    public Button btnAttack, btnItem;
    public InputField playerInput;
    public Text battleGridText;
    public Text bossName;
    public Text characterName;

    public AudioSource answerCorrect;
    public AudioSource answerFail;

    public Slider hpBoss;
    public Slider hpCharacter;

    private float percentageCompletedBoss;
    private float percentageCompletedCharacter;

    private bool victory = false;
    private bool battleOver = false;
    private Navigation navigation = new Navigation();

    private Character character;
    private Boss combatBoss;
    private LeaderboardController leaderboard;
    private int counter = 1;
    private CombatAnimationController animationController;

    void Start()
    {
        character = new Character(1, PersistenceManager.manager.characterName, PersistenceManager.manager.health, new Job(1, "knight"));
        combatBoss = PersistenceManager.manager.stages[PersistenceManager.manager.stageIdentifier].boss;
        animationController = GetComponent<CombatAnimationController>();
        character.health = 20;
        SetupEncounter();
        ShowNextQuestion();
    }


    void Update()
    {
        hpBoss.value = percentageCompletedBoss;
        hpCharacter.value = percentageCompletedCharacter;
        animationController.OnFinishedAttackAnimation();
        animationController.OnFinishedDamageAnimation();
        OnFinishedBattleConclusionAnimation(victory);
        leaderboard = FindObjectOfType<LeaderboardController>();

        if (Input.GetKeyDown("return"))
        {
            TaskOnClick();
        }
    }


    void TaskOnClick()
    {
        if (playerInput.text != "")
        {
            Question currentQuestion = combatBoss.getChallenge().getQuestionById(PersistenceManager.manager.questionCounter + 1);
            ValidateAnswer(currentQuestion);
            if (ValidateVictory())
            {
                bossName.text = "DEFEATED";
                battleGridText.text = battleGridText.text + Environment.NewLine + "BATTLE WON";
                victory = true;
                animationController.BattleConclusionAnimation(true);
            }
            else if (ValidateLoss())
            {
                battleGridText.text = battleGridText.text + Environment.NewLine + "YOU DIED";
                victory = false;
                animationController.BattleConclusionAnimation(false);
            }
            else if (counter <= combatBoss.getChallenge().getQuestions().Count)
            {
                ShowNextQuestion();
            }
        }
        else
        {
            battleGridText.text = battleGridText.text + Environment.NewLine + "You must enter an answer to attack!";
        }
    }


    void SetupEncounter()
    {
        PersistenceManager.manager.previousScene = PersistenceManager.manager.currentScene;
        btnAttack.onClick.AddListener(TaskOnClick);
        btnItem.onClick.AddListener(UseTip);
        hpBoss.maxValue = combatBoss.hp;
        hpBoss.minValue = 0;
        bossName.text = combatBoss.name;
        hpCharacter.maxValue = character.health;
        hpBoss.minValue = 0;
        characterName.text = character.name;
    }


    void ShowNextQuestion()
    {
        playerInput.text = null;
        Question currentQuestion = combatBoss.getChallenge().getQuestionById(PersistenceManager.manager.questionCounter + 1);
        if (currentQuestion.id != 0)
        {
            if (currentQuestion.id == 1)
            {
                battleGridText.text = "You encounter " + combatBoss.name + Environment.NewLine + currentQuestion.question;
            }
            else
            {
                battleGridText.text = currentQuestion.question;
            }
            currentQuestion.complete = true;
        }
    }


    void ValidateAnswer(Question currentQuestion)
    {
        if (currentQuestion.answer.Equals(playerInput.text.ToLower()))
        {
            answerCorrect.Play();
            animationController.AttackPlayerAnimation();
            percentageCompletedBoss += 1;
            combatBoss.getChallenge().addCorrect(currentQuestion);
            combatBoss.hp = combatBoss.hp - 1;
            PersistenceManager.manager.questionCounter++;
            PersistenceManager.manager.characterPoints += 1;
            counter++;
        }
        else
        {
            PersistenceManager.manager.characterPoints -= 1;
            if (!battleOver)
            {
                answerFail.Play();
                animationController.AttackEnemyAnimation();
                percentageCompletedCharacter += 5;
                combatBoss.getChallenge().addMistake(currentQuestion);
                character.health = character.health - 5;
                CheckAnswerSimilarity(playerInput.text.ToLower(), currentQuestion);
            }
        }
    }


    void OnFinishedBattleConclusionAnimation(bool victory)
    {
        if (victory)
        {
            if (animationController.getAnimatorEnemy().GetCurrentAnimatorStateInfo(0).IsName("DragonDeath"))
            {

                animationController.getAnimatorEnemy().enabled = false;
                GameObject.Find("DragonAnimation").transform.localScale = new Vector3(0, 0, 0);
                animationController.getAnimatorCharacter().SetBool("Win", true);

                if (animationController.getAnimatorCharacter().GetCurrentAnimatorStateInfo(0).IsName("KnightWin"))
                {
                    PersistenceManager.manager.characterPoints += 5;
                    PersistenceManager.manager.characterPoints += Convert.ToInt32(PersistenceManager.manager.countdownTimer);
                    if (PersistenceManager.manager.gamePractice)
                    {
                        navigation.OpenScene("StageSelection");
                    }
                    else
                    {
                        navigation.OpenScene(navigation.LevelNavigation());
                    }
                }
            }
        }
        else
        {
            if (animationController.getAnimatorCharacter().GetCurrentAnimatorStateInfo(0).IsName("KnightDie"))
            {

                animationController.getAnimatorCharacter().enabled = false;
                GameObject.Find("KnightAnimation").transform.localScale = new Vector3(0, 0, 0);
                animationController.getAnimatorEnemy().SetBool("Win", true);

                if (animationController.getAnimatorEnemy().GetCurrentAnimatorStateInfo(0).IsName("DragonWin"))
                {
                    if (!PersistenceManager.manager.gamePractice)
                    {
                        leaderboard.SaveCharacterPoints();
                        navigation.OpenScene("GameOver");
                    }
                    else
                    {
                        navigation.OpenScene("StageSelection");
                    }
                }
            }
        }
    }


    void CheckAnswerSimilarity(string answer, Question q)
    {
        if (answer.CompareTo(q.answer) == -1)
        {
            battleGridText.text = battleGridText.text + Environment.NewLine + "You were close!";
        }
    }


    void UseTip()
    {
		bool usageComplete = false;
        Question currentQuestion = combatBoss.getChallenge().getQuestionById(PersistenceManager.manager.questionCounter + 1);
        if (PersistenceManager.manager.hints > 0)
        {
			foreach(Tip tip in currentQuestion.tips)
			{
				if (!tip.used && !usageComplete)
				{
					battleGridText.text = battleGridText.text + Environment.NewLine + tip.tip;
					PersistenceManager.manager.hints = PersistenceManager.manager.hints - 1;
					battleGridText.text = battleGridText.text + Environment.NewLine + "You have " + PersistenceManager.manager.hints + " remaining";
					tip.used = true;
					usageComplete = true;
				}
			}
         
        }
    }


    bool ValidateVictory()
    {
        bool result = false;
        if (combatBoss.hp <= 0)
        {
            battleOver = true;
            result = true;
        }
        return result;
    }


    bool ValidateLoss()
    {
        bool result = false;
        if (character.health <= 0)
        {
            battleOver = true;
            result = true;
        }
        return result;
    }
}
