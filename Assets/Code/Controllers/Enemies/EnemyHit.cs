using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHit : MonoBehaviour
{
    public int playerHealth = 20;
    public GameObject respawnPoint;
    public GameObject[] healthList;
    public AudioSource audioDeath;
    public AudioSource audioHit;

    private int isTriggered = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            audioHit.Play();
            isTriggered++;
            if (isTriggered == 1)
            {
                ManageHealth();
                if (playerHealth <= 0)
                {
                    playerHealth = 20;
                    audioDeath.Play();
                    PersistenceManager.manager.characterPoints = 0;
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D enemy)
    {
        isTriggered--;
        if (isTriggered < 0)
        {
            isTriggered = 0;
        }
    }

    private void ManageHealth()
    {
        playerHealth = playerHealth - 5;

        if (playerHealth <= 15 && playerHealth > 10)
        {
            healthList[3].SetActive(false);
        }
        else if (playerHealth <= 10 && playerHealth > 5)
        {
            healthList[2].SetActive(false);
        }
        else if (playerHealth <= 5 && playerHealth > 0)
        {
            healthList[1].SetActive(false);
        }
        else if (playerHealth < 0)
        {
            healthList[0].SetActive(false);
        }
    }
}
