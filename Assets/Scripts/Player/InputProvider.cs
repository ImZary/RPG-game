using UnityEngine;

public class InputProvider : MonoBehaviour
{
    private PlayerInputAction input;
    public Vector2 movementInputs;
    public bool canMove;


    public void OnEnable()
    {
        if (canMove)
        {
            input = new PlayerInputAction();
            input.Player.Enable();
        }
        else
        {
            OnDisable(); 
        }
    }
    public void OnDisable()
    {
        input.Player.Disable();
    }

    void Update()
    {
        movementInputs = input.Player.Movement.ReadValue<Vector2>();
    }
}
