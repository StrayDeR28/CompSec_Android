using TMPro;
using UnityEngine;

public class MenuScore : MonoBehaviour
{
    [SerializeField] TMP_Text score;

    void Start()
    {
        if (PlayerPrefs.HasKey("TotalPointsForTest1"))
        {
            gameObject.SetActive(true);
            score.text = PlayerPrefs.GetInt("TotalPointsForTest1").ToString();
            print("TotalPointsForTest1 exists, value = " + PlayerPrefs.GetInt("TotalPointsForTest1"));
        }
    }
}