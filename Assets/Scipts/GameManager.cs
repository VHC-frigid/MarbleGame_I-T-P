using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int score;
    public float timer;
    public Transform player;

    public Text hudscore;
    public Text hudTimer;

    public Text subtitle;
    public Text goScore;
    public Text goHighScore;
    public GameObject goPanel;

    bool gameOver;

    public float boostTimer;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gm = this;
        gameOver = false;
        goPanel.SetActive (false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            player.GetComponent<Player>().maxspeed = 30;
        }
        else
        {
            player.GetComponent<Player>().maxspeed = 15;
        }

        hudscore.text = score.ToString();

        float timerRounded = timer;
        timerRounded = MathF.Round(timerRounded * 100);

        timerRounded /= 100;
        
        hudTimer.text = timerRounded.ToString();

        timer -= Time.deltaTime;

        if (timer <= 0 && !gameOver)
        {
            //game over
            Debug.Log("Gameover");
            gameOver = true;
            goPanel.SetActive(true);
            Time.timeScale = 0;

            if(score > PlayerPrefs.GetInt("highscore", 0))
            {
                subtitle.text = "Congrats!";
                PlayerPrefs.SetInt("highscore", score);
            }
            else
            {
                subtitle.text = "Skill issue >:)";
            }

            goScore.text = score.ToString();
            goHighScore.text = PlayerPrefs.GetInt("highscore",0).ToString();

        }
        else if(!gameOver)
        {
            timer -= Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
