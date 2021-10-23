using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController Player;
    public Bullet bullet;
    public ParticleSystem explotion;
    public ParticleSystem asteroidExplotion;
    public int Score = 0;

    public int lives = 3;
    public float respawnTime=3f;

    public TMP_Text ScoreBoard;

    public TMP_Text livesRemaining;

    private void Start()
    {
        livesRemaining.text = lives.ToString();
    }
    public void AsteroidDestroy(asteroid asteroid)
    {
        asteroidExplotion.transform.position = asteroid.transform.position;
        asteroidExplotion.Play();

        if (asteroid.size < 0.75f)
        {
            Score += 100;
        }else if (asteroid.size < 1f)
        {
            Score += 50;
        }
        else
        {
            Score += 25;
        }

        ScoreBoard.text = Score.ToString();
    }
    public void Died()
    {
        explotion.transform.position = Player.transform.position;
        explotion.Play();
        Player.gameObject.SetActive(false);
        bullet.gameObject.SetActive(false);

     
        lives--;
        livesRemaining.text = lives.ToString();
        if (lives == 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnTime);
        }
        
    }

    private void Respawn()
    {
        Player.transform.position = Vector3.zero;

        Player.gameObject.SetActive(true);
        bullet.gameObject.SetActive(true);
        
        
    }
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
