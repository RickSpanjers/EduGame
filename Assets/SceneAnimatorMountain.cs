using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneAnimatorMountain : MonoBehaviour
{
    public GameObject timeline;
    private float time = 14.0f;
    private float loadLevel = 4.0f;

    void Start()
    {
        StartCoroutine(Sequence());
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            SceneManager.LoadScene("MountainAndCave");
        }

        time -= Time.deltaTime;

        if (time <= 0) { 
            loadLevel -= Time.deltaTime;

            if (loadLevel <= 0)
            {
                SceneManager.LoadScene("MountainAndCave");
            }
        }
    }

    IEnumerator Sequence()
    {
        timeline.SetActive(true);
        yield return new WaitForSeconds(14.0f);
        timeline.SetActive(false);
    }
}
