using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public GameObject gameManager;

    private int initialSpeedX;
    private int initialSpeedY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bounce(collision);
    }

    public void Start()
    {
        initialSpeedX = Random.Range(0, 2);
        initialSpeedY = Random.Range(0, 2);

        if (initialSpeedX == 0)
        {
            initialSpeedX = -1;
        }

        if (initialSpeedY == 0)
        {
            initialSpeedY = -1;
        }

        rb.velocity = new Vector2(initialSpeedX * speed * Time.deltaTime, initialSpeedY * speed * Time.deltaTime);
    }

    private void Bounce(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "BounceY":
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
                return;
            case "BounceX":
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
                return;
            case "GameOverPlayer1":
                gameManager.GetComponent<GameManager>().GameOver(true);
                return;
            case "GameOverPlayer2":
                gameManager.GetComponent<GameManager>().GameOver(false);
                return;
        }
    }
}
