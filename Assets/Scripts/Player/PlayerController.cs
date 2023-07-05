using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 inputs;
    [SerializeField] private float speed;
    [SerializeField] private Animator movementAnimator;
    [SerializeField] private Sprite[] sprites;
    private Rigidbody2D rb;
    private InputProvider inputProvider;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        inputProvider = GetComponent<InputProvider>();
        rb = GetComponent<Rigidbody2D>();    
    }

    void FixedUpdate()
    {
        inputs = inputProvider.movementInputs;
        if (inputs.y == 1 || inputs == new Vector2(inputs.x,1))
        {
            spriteRenderer.sprite = sprites[0];
            transform.localScale = new Vector2(1, 1);
        }
        if (inputs.y == -1 || inputs == new Vector2(inputs.x, -1))
        {
            spriteRenderer.sprite = sprites[1];
            transform.localScale = new Vector2(1, 1);
        }
        if (inputs.x == 1)
        {
            spriteRenderer.sprite = sprites[2];
            transform.localScale = new Vector2(1, 1);
        }
        if (inputs.x == -1)
        {
            spriteRenderer.sprite = sprites[2];
            transform.localScale = new Vector2(-1, 1);
        }
        rb.velocity = inputs * speed;
    }
}
