using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTotalScore : MonoBehaviour
{
    [SerializeField] public SummOfPointsSO summOfPointsForTest1;
    [SerializeField] public SummOfPointsSO totalSummOfPointsForTest1;

    public void SaveTotalPoints()//тут можно передавать но id тестов, но у нас он один
    {
        if(totalSummOfPointsForTest1.points < summOfPointsForTest1.points) totalSummOfPointsForTest1.points = summOfPointsForTest1.points;
    }
}
