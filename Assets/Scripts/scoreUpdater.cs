using System;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class scoreUpdater : MonoBehaviour
{
    private int hiscore;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!(PlayerPrefs.HasKey("hiScore")))
        {
            hiscore = 0;
        }
        else
        {
            hiscore = PlayerPrefs.GetInt("hiScore");
        }
        scoreText.text = string.Format("Score \n {0:0000}", score);
        hiscoreText.text = string.Format("Hi-Score \n  {0:0000}", hiscore);
    }
}
