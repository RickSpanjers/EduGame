using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public Collider2D FrontAttackTrigger;
    public Collider2D BackAttackTrigger;
    public AudioSource attackAudio;

    private InputManager inputManager;

    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.3f;
    private Animator animator;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        FrontAttackTrigger.enabled = false;
        BackAttackTrigger.enabled = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (inputManager.GetButtonDown("Attack") && !attacking)
        {
            attackAudio.Play();
            attacking = true;
            attackTimer = attackCd;

            FrontAttackTrigger.enabled = true;
            BackAttackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                animator.SetBool("IsAttacking", attacking);
            }
            else
            {
                attacking = false;
                FrontAttackTrigger.enabled = false;
                BackAttackTrigger.enabled = false;
                animator.SetBool("IsAttacking", attacking);
            }
        }
    }
}