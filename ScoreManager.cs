using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;



    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //code to change the score and the text display
    public void ChangeScore(int coinValue)
    {

        score = score + coinValue;
        moveusers.Instance.score = score;
        text.text = "Score:" + score.ToString();
    }
}
