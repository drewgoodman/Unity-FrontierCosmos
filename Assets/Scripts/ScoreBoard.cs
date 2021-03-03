using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    int scoreDigitMax = 8;
    TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = new string('0', scoreDigitMax);
    }

    public void ModifyScore(int amountToModify)
    {
        score += amountToModify;
        scoreText.text = score.ToString().PadLeft(scoreDigitMax, '0');
    }

}
