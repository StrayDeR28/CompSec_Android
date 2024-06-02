using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class BuildScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image image;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text dateTime;

    public void SetData(Info info)
    {
        score.text = "впо: " + info.Malware + " соц: " + info.Social + " физ: " + info.Physic + " очки: " + info.Score + "/40";
        dateTime.text = info.time + ' ' + info.date;
    }
}
