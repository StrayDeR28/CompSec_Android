using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrintResults : MonoBehaviour
{
    [SerializeField] public SummOfPointsSO summOfPointsForTest;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text mark;
    [SerializeField] private int maxScore = 40;

    public void PrintScore()
    {
        score.text = summOfPointsForTest.points.ToString() + "/" + maxScore.ToString();
        float percent = (float)summOfPointsForTest.points / (float)maxScore;
        if (percent > 0.85) mark.text = "Отлично!";
        else if (percent > 0.7) mark.text = "Хорошо!";
        else if (percent > 0.5) mark.text = "Неплохо";
        else if (percent <= 0.5) mark.text = "Стоит повторить";
    }
}
