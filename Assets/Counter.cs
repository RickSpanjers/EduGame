using UnityEngine;

public class Counter : MonoBehaviour
{
    public GameObject eagle;

    private float time = 30.0f;
    private int count = 0;

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            if (count == 0)
            {
                EnableEagle();
                count++;
            }
        }
    }

    private void EnableEagle()
    {
        eagle.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Eagle")
        {
            eagle.SetActive(false);
            eagle.transform.position = transform.position;
            time = 10.0f;
            count = 0;
        }
    }
}
