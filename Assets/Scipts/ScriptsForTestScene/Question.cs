using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Question : MonoBehaviour
{
    [SerializeField] private enum TypeOfQuestion { OneRightAnswer, TwoRightAnswers };

    [SerializeField] private TypeOfQuestion typeOfQuestion;
    [SerializeField] public int id;
    [SerializeField] public SummOfPointsSO summOfPointsForTest;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private int[] rightAnswers;
    [SerializeField] public int rightAnswerCost = 1;
    [SerializeField] private Sprite crest;
    [SerializeField] private Sprite greenArrow;
    [SerializeField] private Sprite redCircle;
    [SerializeField] private Sprite greenCircle;
    [SerializeField] private Sprite defaultArrow;
    [SerializeField] private Sprite defaultCircle;

    [SerializeField] private List<GameObject> answers;

    public void ChangeInteractabilityForToggles(bool IsInteractable)
    {
        foreach (var answer in answers)
        {
            if (answer.GetComponent<Toggle>() != null) 
            {
                if (!IsInteractable) answer.GetComponent<Toggle>().interactable = false;
                else answer.GetComponent<Toggle>().interactable = true;
                answer.GetComponent<AnswerTypes>().ChangeCheckmark((int)typeOfQuestion, IsInteractable, defaultCircle, defaultArrow, crest, greenArrow, redCircle, greenCircle);
            }
        }
    }
}
