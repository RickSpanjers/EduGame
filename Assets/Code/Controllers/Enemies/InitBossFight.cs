using System;
using UnityEngine;

public class InitBossFight : MonoBehaviour
{
    public bool dynamic;
    public GameObject boss;
    public GameObject playerObject;
    public GameObject returnPoint;
    public static bool stop = false;
    public Animator animatorDialogue;

    private Vector3 startLocation;
    private Vector3 playerLocation;
    private bool hasHit = false;
    private bool hasSeen = false;
    private bool hasLost = false;
    private Animator animator;

    void Start()
    {
        animator = boss.GetComponent<Animator>();
        Data data = Save.LoadPlayerData();

        Player player = playerObject.GetComponent<Player>();
        player.previousLevel = data.currentLevel;
        player.health = data.health;
        player.hints = data.hintLog;

        Save.SavePlayer(player);

        startLocation = boss.transform.position;
    }

    void Update()
    {
        if (hasHit)
        {
            Attack();
        }
        if (hasSeen)
        {
            FollowPlayer();
        }
        if (hasLost)
        {
            ReturnBack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (dynamic == true)
            {
                hasLost = false;
                hasSeen = true;
                stop = false;
                animator.SetBool("IsWalking", true);
            }
            else
            {
                Destroy(collision.GetComponent<PlayerPlatformController>());
                hasHit = true;
                animator.SetBool("IsWalking", true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (dynamic == true)
            {
                hasSeen = false;
                hasLost = true;
            }
        }
    }

    private void Attack()
    {
        boss.transform.position += Vector3.left * 0.1f;
    }

    private void FollowPlayer()
    {
        if (playerObject.transform.position.x > boss.transform.position.x)
        {
            boss.transform.position -= Vector3.left * 0.1f;
            boss.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            boss.transform.position += Vector3.left * 0.1f;
            boss.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void ReturnBack()
    {
        if (!stop)
        {
            if (startLocation.x > boss.transform.position.x)
            {
                boss.transform.position -= Vector3.left * 0.1f;
                boss.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                boss.transform.position += Vector3.left * 0.1f;
                boss.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            hasLost = false;
            animator.SetBool("IsWalking", false);
        }
    }
}