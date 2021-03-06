﻿using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public GameObject gameManager;
    public AudioManager audioManager;

    private int initialSpeedX;
    private int initialSpeedY;

    private float relativeIntersect;
    private float normalizedRelativeIntersect;
    private float bounceAngle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bounce(collision);
    }

    public void Play()
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

        rb.velocity = new Vector2(initialSpeedX * speed, initialSpeedY * speed);
    }

    private void Bounce(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Wall":
                audioManager.GetComponent<AudioManager>().Bounce();

                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
                return;

            case "Paddle1":
            case "Paddle2":
                relativeIntersect = collision.transform.position.y - gameObject.transform.position.y;
                normalizedRelativeIntersect = (relativeIntersect / (collision.gameObject.transform.localScale.y / 2));
                bounceAngle = normalizedRelativeIntersect * (5 * Mathf.PI / 12);

                audioManager.GetComponent<AudioManager>().Bounce();

                rb.velocity = new Vector2(-rb.velocity.x, -Mathf.Sin(bounceAngle) * speed);
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
