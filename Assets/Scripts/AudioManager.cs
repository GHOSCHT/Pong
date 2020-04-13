using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource src;
    public AudioClip bounce;
    public AudioClip gameOver;

    public void Bounce()
    {
        src.clip = bounce;
        src.volume = 0.1f;
        src.Play();
    }
    public void GameOver()
    {
        src.clip = gameOver;
        src.volume = 0.3f;
        src.Play();
    }
}
