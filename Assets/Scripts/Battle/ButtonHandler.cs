using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public bool isButtonSelected;

    public int selectionInt;

    public Sprite selectedSprite;
    public Sprite deselectedSprite;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    void Update()
    {
        if (isButtonSelected)
        {
            spriteRenderer.sprite = selectedSprite;
        }
        else
        {
            spriteRenderer.sprite = deselectedSprite;
        }
    }
}
