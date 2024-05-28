using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTotalScore : MonoBehaviour
{
    [SerializeField] public SummOfPointsSO summOfPointsForTest1;

    private void Awake() //для очистки
    {
        PlayerPrefs.DeleteKey("TotalPointsForTest1");

    }
    public void SaveTotalPoints()//тут можно передавать но id тестов, но у нас он один
    {
        if (PlayerPrefs.HasKey("TotalPointsForTest1"))
        {
            if(PlayerPrefs.GetInt("TotalPointsForTest1") < summOfPointsForTest1.points)
            {
                PlayerPrefs.SetInt("TotalPointsForTest1", summOfPointsForTest1.points);
                print("TotalPointsForTest1 exists, value = " + PlayerPrefs.GetInt("TotalPointsForTest1"));
            }
        }
        else
        {
            PlayerPrefs.SetInt("TotalPointsForTest1", summOfPointsForTest1.points);
            print("TotalPointsForTest1 created, value = " + PlayerPrefs.GetInt("TotalPointsForTest1"));
        }
    }
}
