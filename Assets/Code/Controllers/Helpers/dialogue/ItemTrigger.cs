using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    private bool isKeyPressed = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isKeyPressed)
            {
                isKeyPressed = true;
                TriggerOpen();
            }
            else
            {
                isKeyPressed = false;
                TriggerClose();
            }
        }
    }

    public void TriggerOpen()
    {
        FindObjectOfType<ItemManager>().OpenItems();
    }

    public void TriggerClose()
    {
        FindObjectOfType<ItemManager>().CloseItems();
    }
}
