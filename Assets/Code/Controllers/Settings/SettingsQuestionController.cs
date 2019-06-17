using Assets.Code.Models.Game;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsQuestionController : MonoBehaviour
{
    public Text questionText;
    public Text questionNr;
    public Text questionName;
    public Text questionAnswer;
	public Text questionFirstHint;
	public Text questionSecondHint;
	public Text questionThirdHint;
    public Button addQuestion;
    public Button saveQuestions;

    void Start()
    {
        RefreshQuestions();
    }

    void Update()
    {
        addQuestion.onClick.AddListener(UpdateQuestion);
    }

    void UpdateQuestion()
    {
        foreach (Question q in PersistenceManager.manager.allQuestions)
        {
            if (q.id == int.Parse(questionNr.text))
            {
                q.question = questionName.text;
                q.answer = questionAnswer.text;
				List<Tip> tips = new List<Tip>();
				Tip tip = new Tip(questionFirstHint.text);
				Tip secondTip = new Tip(questionSecondHint.text);
				Tip thirdTip = new Tip(questionThirdHint.text);
				tips.Add(tip);
				tips.Add(secondTip);
				tips.Add(thirdTip);
				q.tips = tips;
            }
        }
        Save.SaveQuestions(PersistenceManager.manager.allQuestions);
        RefreshQuestions();
    }

    void RefreshQuestions()
    {
        questionText.text = "";
        foreach (Question q in PersistenceManager.manager.allQuestions)
        {
            questionText.text = questionText.text + Environment.NewLine + q.id + " " + q.question;
        }
    }
}