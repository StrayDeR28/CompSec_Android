using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCurrentPoints : MonoBehaviour
{
    [SerializeField] public SummOfPointsSO summOfCurrentPointsForTest;

    public void ResetPoints()
    {
        summOfCurrentPointsForTest.points = 0;
    }
}
