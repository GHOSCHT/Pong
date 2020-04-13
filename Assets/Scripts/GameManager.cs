using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public int player1Score = 0;
    public int player2Score = 0;
    public int round = 0;
    public int minSpeed = 200;
    public int maxSpeed = 900;

    public int speed;

    private GameObject ball;

    private void Start()
    {
        speed = minSpeed;
        SpawnBall();
    }

    public void GameOver(bool isPlayer1)
    {
        if (isPlayer1)
        {
            Debug.Log("Player 2 wins!");
            player1Score++;
        }
        else
        {
            Debug.Log("Player 1 wins!");
            player2Score++;
        }

        Destroy(ball);

        SpawnBall();

        round++;

        speed += 50;

        if (speed > maxSpeed)
            speed = maxSpeed;
    }

    private void SpawnBall()
    {
        ball = Instantiate(ballPrefab);
        ball.GetComponent<BallController>().gameManager = gameObject;
        ball.GetComponent<BallController>().speed = speed;
        ball.GetComponent<BallController>().Start();
    }
}
