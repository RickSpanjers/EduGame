using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Challenge
{

    public List<Question> questions = new List<Question>();
    public List<Question> correctQuestions = new List<Question>();
    public List<Question> failedQuestions = new List<Question>();

    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }

    public Challenge(int id, string name, string description, List<Question> questions)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.questions = questions;
    }

    public Challenge()
    {

    }

    public void setQuestions(List<Question> questions)
    {
        this.questions = questions;
    }

    public List<Question> getQuestions()
    {
        return questions;
    }

    public void addQuestion(Question q)
    {
        questions.Add(q);
    }

    public void removeQuestion(Question q)
    {
        this.questions.Remove(q);
    }

    public void addMistake(Question q)
    {
        this.failedQuestions.Add(q);
    }

    public void addCorrect(Question q)
    {
        this.correctQuestions.Add(q);
    }

    public List<Question> getCorrectQuestions()
    {
        return this.correctQuestions;
    }

    public List<Question> getMistakes()
    {
        return this.failedQuestions;
    }

    public Question getQuestionById(int id)
    {
        Question result = new Question(0, null, null, null);
        foreach (Question q in questions)
        {
            if (q.id == id)
            {
                result = q;
            }
        }
        return result;
    }
}
