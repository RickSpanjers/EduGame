using UnityEngine;
using UnityEngine.SceneManagement;

public class BossNavigation : MonoBehaviour
{
    public string level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(level);
        }
    }
}
