using System.Collections;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    public GameObject open;
    public GameObject close;
    public Animator animator;

    void Start()
    {
        open.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            open.SetActive(true);
            close.SetActive(false);
            animator.SetBool("IsOpen", true);
            AddHint();
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
    }

    void AddHint()
    {
        PersistenceManager.manager.hints = PersistenceManager.manager.hints + 1;
    }
}
