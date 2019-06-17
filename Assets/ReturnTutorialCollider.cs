using UnityEngine;

public class ReturnTutorialCollider : MonoBehaviour
{
    public Canvas tutorialCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            if (tutorialCanvas.enabled != true)
            {
                tutorialCanvas.enabled = true;
            }
        }
    }
}
