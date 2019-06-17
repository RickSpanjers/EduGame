using Assets.Code.Models.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Question
{
    public int id { get; set; }
    public string question { get; set; }
    public string answer { get; set; }
    public bool complete { get; set; }
    public List<Tip> tips { get; set; }
    public bool inChallenge { get; set; }

    public Question(int id, string question, string answer, List<Tip> tips)
    {
        this.id = id;
        this.question = question;
        this.answer = answer;
		this.tips = tips;
    }
}
