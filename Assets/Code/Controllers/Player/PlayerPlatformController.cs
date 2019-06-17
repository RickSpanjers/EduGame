using UnityEngine;

public class PlayerPlatformController : PhysicsObject
{
    public float maxSpeed = 7;
    public float takeOfSpeed = 7;
    public GameObject respawnPoint;
    public AudioSource fallToDeath;

    private InputManager inputManager;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float deathTimer = 2.0f;
    private float timeInAir = 0.0f;
    private bool moving = false;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move.x));

        Jump();
        FlipSprite(move);

        if (!grounded)
        {
            timeInAir += Time.deltaTime;

            if (timeInAir >= deathTimer)
            {
                fallToDeath.Play();
                gameObject.transform.position = respawnPoint.transform.position;
                timeInAir = 0.0f;
            }
        }
        else
        {
            timeInAir = 0.0f;
        }

        animator.SetBool("IsGrounded", grounded);

        targetVelocity = move * maxSpeed;
    }

    public void Jump()
    {
        if (inputManager.GetButtonDown("Jump") && grounded)
        {
            velocity.y = takeOfSpeed;
            animator.SetBool("IsGrounded", grounded);
            timeInAir = 0.0f;
            Data data = Save.LoadPlayerData();

            Player player = GetComponent<Player>();
            player.currentLevel = data.currentLevel;
            player.previousLevel = data.currentLevel;
            player.health = data.health;
            player.hints = data.hintLog;

            Save.SavePlayer(player);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
            timeInAir = 0.0f;
        }
    }

    public void FlipSprite(Vector2 move)
    {
        bool flipSprite = spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f);

        if (flipSprite)
        {
            if (move == Vector2.zero || move.x > 0.0f)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
    }
}
