using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] ghosts;
    public GameObject pacman;
    public Transform pellets;

    public int dotCount;
    public int score { get; private set; }
    public int lives { get; private set; }
    public TMP_Text scoreText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if(lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    void NewRound()
    {
        foreach(Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    void ResetState()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
    }

    void GameOver()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);
    }

    void SetScore(int score)
    {
        this.score = score;
    }

    void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void GhostEaten(Ghost ghost)
    {
        SetScore(this.score + ghost.points);
    }

    public void PacmanEaten()
    {
        pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);
        if(this.lives > 0)
        {
            Invoke(nameof(ResetState), 3f);
        }
        else
        {
            GameOver();
        }
    }
}
