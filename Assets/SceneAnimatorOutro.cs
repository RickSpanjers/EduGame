using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneAnimatorOutro : MonoBehaviour
{
    public GameObject playerMove;
    public RawImage rawImage;

    private bool canFade = false;
    private float time = 16.0f;
    private float loadLevel = 4.0f;

    void Start()
    {
        StartCoroutine(Sequence());
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            SceneManager.LoadScene("Victory");
        }

        time -= Time.deltaTime;

        if (time <= 0)
        {
            canFade = true;
        }

        if (canFade)
        {
            StartCoroutine(Fade(3, Color.clear, Color.black));
            loadLevel -= Time.deltaTime;

            if (loadLevel <= 0)
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }

    IEnumerator Sequence()
    {
        playerMove.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        yield return new WaitForSeconds(13.0f);

        playerMove.SetActive(false);

    }

    public IEnumerator Fade(float duration, Color startColor, Color endColor)
    {
        float start = Time.time;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed = Time.time - start;
            float normalizedTime = Mathf.Clamp(elapsed / duration, 0, 1);
            rawImage.color = Color.Lerp(startColor, endColor, normalizedTime);

            yield return null;
        }
    }
}
