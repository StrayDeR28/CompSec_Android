using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionDataSO", menuName = "ScriptableObjects/QuestionDataSO", order = 2)]

public class QuestionDataSO : ScriptableObject
{
    [SerializeField] public string questionType = "QuestionOneRightAnswer";
    [SerializeField] public string questionText = "What?";
    [SerializeField] public int rightAnswerCost = 1;
    [SerializeField] public List<string> answersText = new List<string> {"1","2","3","4"};// x4
    [SerializeField] public List<string> answersType = new List<string> {"None", "Add", "None", "Sub"};// add, sub, none
    public int id = 0;
    public SummOfPointsSO summOfPointsSO;
}
