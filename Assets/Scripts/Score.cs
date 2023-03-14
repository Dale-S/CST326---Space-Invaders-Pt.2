using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    private int hiscore;
    private int score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnEnemyDestroyed += OnEnemyDestroyed;
    }

    private void OnEnemyDestroyed(string name)
    {
        if (name == "Enemy1(Clone)")
        {
            score += 30;
            scoreText.text = string.Format("Score \n {0:0000}", score);
        }
        if (name == "Enemy2(Clone)")
        {
            score += 20;
            scoreText.text = string.Format("Score \n {0:0000}", score);
        }
        if (name == "Enemy3(Clone)")
        {
            score += 10;
            scoreText.text = string.Format("Score \n {0:0000}", score);
        }
        Debug.Log("Enemy Destroyed");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            int highScore = 0;
            if(score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("hiScore", highScore);
                PlayerPrefs.Save();
            }
        }
        if (!(PlayerPrefs.HasKey("hiScore")))
        {
            int highScore = 0;
            if(score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("hiScore", highScore);
                PlayerPrefs.Save();
            }
        }
        hiscore = PlayerPrefs.GetInt("hiScore");
        scoreText.text = string.Format("Score \n {0:0000}", score);
        hiscoreText.text = string.Format("Hi-Score \n  {0:0000}", hiscore);
        if(PlayerPrefs.HasKey("hiScore"))
        {
            if(score > PlayerPrefs.GetInt("hiScore")) 
            {
                    PlayerPrefs.SetInt("hiScore", score);
                    PlayerPrefs.Save();
            }
        }
    }
}
