using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject jump_foward;
    public GameObject jump_back;
    public bool isFroggy;
    public Rigidbody2D frog_body;
    public GameObject platforms;
    public bool isHopper;

    private TilemapCollider2D platform_collider;
    private bool isForward = true;
    private int count = 0;
    private SpriteRenderer spriteRenderer;
    private static int movementCount = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isFroggy)
        {
            platform_collider = platforms.GetComponent<TilemapCollider2D>();
        }
    }

    void FixedUpdate()
    {
        if (isForward)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (count == 0)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                count++;
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (count == 1)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                count--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFroggy)
        {
            if (collision.gameObject.name.StartsWith("Jump"))
            {
                if (collision.gameObject.name == "Jump_Back")
                {
                    frog_body.AddForce(Vector2.right * 13f);
                    movementCount = 0;
                }
                else
                {
                    frog_body.AddForce(Vector2.left * 13f);
                }
                frog_body.AddForce(Vector2.up * 5f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFroggy)
        {
            foreach (ContactPoint2D hitPos in collision.contacts)
            {
                if (hitPos.collider.gameObject.name == "Platforms")
                {
                    movementCount++;
                }
            }
            if (movementCount == 2)
            {
                if (frog_body.IsTouching(platform_collider))
                {
                    isForward ^= true;
                }
            }
            else
            {
                if (isHopper)
                {
                    isForward ^= false;
                }
                else
                {
                    isForward = true;
                }
            }
        }
        else if (collision.gameObject.tag == "Platforms")
        {
            isForward ^= true;
        }
    }
}
