using UnityEngine;

public class SideWalk : MonoBehaviour
{
    public GameObject leftSpawnPoint;
    public GameObject rightSpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (gameObject.name == "LeftSpawnPoint")
            {
                collision.gameObject.transform.position = rightSpawnPoint.transform.position;
            }
            else if (gameObject.name == "RightSpawnPoint")
            {
                collision.gameObject.transform.position = leftSpawnPoint.transform.position;
            }
        }
    }

}
