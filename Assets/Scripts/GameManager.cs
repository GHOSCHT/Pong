using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject player1ScoreDisplay;
    public GameObject player2ScoreDisplay;
    public GameObject countdownDisplay;
    public AudioManager audioManager;
    public int countdownTime = 3;
    public float minSpeed = 1;
    public float maxSpeed = 5;
    public float speedIncrease = 0.5f;

    private GameObject ball;
    private int player1Score = 0;
    private int player2Score = 0;
    private float speed;

    private void Start()
    {
        speed = minSpeed;
        StartCoroutine(Countdown());
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

        StartCoroutine(Countdown());
    }

    private void SpawnBall()
    {
        ball = Instantiate(ballPrefab);
        ball.GetComponent<BallController>().gameManager = gameObject;
        ball.GetComponent<BallController>().speed = speed;
        ball.GetComponent<BallController>().audioManager = audioManager;
        ball.GetComponent<BallController>().Play();
    }

    IEnumerator Countdown()
    {
        countdownDisplay.GetComponent<TextMeshProUGUI>().enabled = true;
        int time = countdownTime;

        while (time > 0)
        {
            countdownDisplay.GetComponent<TextMeshProUGUI>().text = time.ToString();

            audioManager.Countdown();

            yield return new WaitForSeconds(1f);

            time--;
        }

        countdownDisplay.GetComponent<TextMeshProUGUI>().enabled = false;

        SpawnBall();
    }
}
