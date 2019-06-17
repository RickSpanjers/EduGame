using Assets.Code.Repository;
using Assets.Code.Repository.MySQL;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboards : MonoBehaviour
{

    public Text list;

    private List<Score> scores = new List<Score>();
    private ScoreRepository scoreRepo = new ScoreRepository(new ScoreMySQLContext());

    void Start()
    {
        scores = scoreRepo.RetrieveHighscores();
        SetLeaderBoard();
    }

    private void SetLeaderBoard()
    {
        foreach (var score in scores)
        {
            list.text += score.score + " - " + score.name + "\n";
        }
    }

}