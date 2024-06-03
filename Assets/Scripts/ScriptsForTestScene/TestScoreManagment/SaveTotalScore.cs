using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTotalScore : MonoBehaviour
{
    [SerializeField] public SummOfPointsSO summOfPointsForTest1;

    public void SaveTotalPoints()//тут можно передавать но id тестов, но у нас он один
    {
        if (PlayerPrefs.HasKey("TotalPointsForTest1"))
        {
            // if (PlayerPrefs.GetInt("TotalPointsForTest1") < summOfPointsForTest1.points)
            // {
            PlayerPrefs.SetInt("TotalPointsForTest1", summOfPointsForTest1.points);
            // }
        }
        else
        {
            PlayerPrefs.SetInt("TotalPointsForTest1", summOfPointsForTest1.points);
        }
    }
}
