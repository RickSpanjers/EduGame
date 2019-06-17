using UnityEngine;
using UnityEngine.UI;

public class AttackTrigger : MonoBehaviour
{
    public Text hintAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == true && collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            AddHint();
        }
    }

    void AddHint()
    {
        PersistenceManager.manager.hints = PersistenceManager.manager.hints + 1;
        PersistenceManager.manager.characterPoints += 1;
    }
}
