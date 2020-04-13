using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject player1ScoreDisplay;
    public GameObject player2ScoreDisplay;
    public AudioManager audioManager;
    public int minSpeed = 300;
    public int maxSpeed = 900;
    public int speedIncrease = 25;

    private GameObject ball;
    private int player1Score = 0;
    private int player2Score = 0;
    private int speed;

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
            player1ScoreDisplay.GetComponent<TextMeshProUGUI>().text = player1Score.ToString();
        }
        else
        {
            Debug.Log("Player 1 wins!");
            player2Score++;
            player2ScoreDisplay.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();
        }

        audioManager.GameOver();

        Destroy(ball);


        speed += speedIncrease;

        if (speed > maxSpeed)
            speed = maxSpeed;

        SpawnBall();
    }

    private void SpawnBall()
    {
        ball = Instantiate(ballPrefab);
        ball.GetComponent<BallController>().gameManager = gameObject;
        ball.GetComponent<BallController>().speed = speed;
        ball.GetComponent<BallController>().audioManager = audioManager;
        ball.GetComponent<BallController>().Play();
    }
}
