using TMPro;
using UnityEngine;

public class MenuScore : MonoBehaviour
{
    [SerializeField] TMP_Text score;

    /*private void Awake() //для очистки
    {
         PlayerPrefs.DeleteKey("TotalPointsForTest1");
    }*/
    void Start()
    {
        if (PlayerPrefs.HasKey("TotalPointsForTest1"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            score.text = PlayerPrefs.GetInt("TotalPointsForTest1").ToString() + "/40";
            print("TotalPointsForTest1 exists, value = " + PlayerPrefs.GetInt("TotalPointsForTest1"));
        }
    }
}