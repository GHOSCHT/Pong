using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 500;
    public bool isPlayer1 = true;
    public string player1InputMethod = "Vertical";
    public string player2InputMethod = "Horizontal";

    private string inputMethod;
    private float movementInput;

    private void Update()
    {
        if (isPlayer1)
        {
            inputMethod = player1InputMethod;
        }
        else
        {
            inputMethod = player2InputMethod;
        }

        movementInput = Input.GetAxis(inputMethod);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, movementInput * Time.deltaTime * speed);
    }
}
