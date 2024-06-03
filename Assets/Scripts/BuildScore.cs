using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildScore : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text dateTime;

    public void SetData(Info info)
    {
        score.text = "ВПО:" + info.Malware + " Соц:" + info.Social + " Физ:" + info.Physic + " <color=#2A9D8F>Очки: " + info.Score + "/40</color>";
        dateTime.text = info.time + ' ' + info.date;
    }
}
