using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float time = 300;

    private Text counter;

    void Start()
    {
        PersistenceManager.manager.countdownTimer = time;
        counter = GetComponent<Text>();
        counter.text = time.ToString();
    }

    void Update()
    {
        time -= Time.deltaTime;
        counter.text = time.ToString("f0");
        PersistenceManager.manager.countdownTimer = time;

        if (time <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
