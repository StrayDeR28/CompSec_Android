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
    [SerializeField] public int rightAnswerCost = 1;
    [SerializeField] private Sprite crest;
    [SerializeField] private Sprite greenArrow;
    [SerializeField] private Sprite redCircle;
    [SerializeField] private Sprite greenCircle;
    [SerializeField] private Sprite defaultArrow;
    [SerializeField] private Sprite defaultCircle;

    [SerializeField] private List<GameObject> answers;

    /*    private void Awake()
        {
            ShuffleAnswers();
        }
    */
    public void SetQuestionDataFromSO(QuestionDataSO questionDataSO)
    {
        switch (questionDataSO.questionType)//передали тип
        {
            case "QuestionOneRightAnswer":
                typeOfQuestion = TypeOfQuestion.OneRightAnswer;
                break;
            case "QuestionTwoRightAnswer":
                typeOfQuestion = TypeOfQuestion.TwoRightAnswers;
                break;
            default:
                typeOfQuestion = TypeOfQuestion.OneRightAnswer;
                break;
        }
        questionText.text = questionDataSO.questionText;
        id = questionDataSO.id;
        rightAnswerCost = questionDataSO.rightAnswerCost;
        summOfPointsForTest = questionDataSO.summOfPointsSO;
        for (int i = 0; i < answers.Count; i++)
        {
            if (answers[i].GetComponent<AnswerTypes>() != null)
            {
                answers[i].GetComponent<AnswerTypes>().SetDataFromSO(questionDataSO.rightAnswerCost, questionDataSO.answersText[i], questionDataSO.answersType[i]);
            }
            else print("Error in Answer list. Current element:" + answers[i]);
        }
    }

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
    public void ShuffleAnswers()
    {
        List<GameObject> elementsToShuffle = new List<GameObject>();//нуженг доп лист, т.к. в иерархии сначала идет текст вопроса, его нельзя перемешивать

        for (int i = 1; i < answers.Count; i++)
        {
            elementsToShuffle.Add(answers[i]);
        }

        // Перемешиваем элементы в новом списке
        for (int i = 0; i < elementsToShuffle.Count; i++)
        {
            GameObject temp = elementsToShuffle[i];
            int randomIndex = Random.Range(i, elementsToShuffle.Count);
            elementsToShuffle[i] = elementsToShuffle[randomIndex];
            elementsToShuffle[randomIndex] = temp;
        }

        // Применение перемешанного порядка к иерархии, начиная с индекса 1
        for (int i = 0; i < elementsToShuffle.Count; i++)
        {
            elementsToShuffle[i].transform.SetSiblingIndex(i + 1);
        }
    }
}
