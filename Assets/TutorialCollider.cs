using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCollider : MonoBehaviour
{
    public Canvas tutorialCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            if (tutorialCanvas.enabled != false)
            {
                tutorialCanvas.enabled = false;
            }
        }
    }
}
