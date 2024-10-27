using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class scoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    public static scoreKeeper instance;
    public Text scoreText;
    public Text highScore;
    public Text lives;
    int score = -1;
    int highS = 0;
    int life = 3;
    private void Awake(){
        instance = this;
    }
    void Start()
    {
        highS = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        highScore.text = "Highscore: " + highS.ToString();
        lives.text = "Lives: x" + life.ToString();
    }

    // Update is called once per frame
    public void AddPoints(){
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        if(highS < score)
            PlayerPrefs.SetInt("highscore", score);

    }
}
