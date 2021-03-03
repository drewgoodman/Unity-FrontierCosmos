using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;

    public void ModifyScore(int amountToModify)
    {
        score += amountToModify;
        print("New Score!: " + score);
    }

}
