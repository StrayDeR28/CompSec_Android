using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsList : MonoBehaviour
{
    [SerializeField] private List<QuestionDataSO> easyQuestionsDataList;
    [SerializeField] private List<QuestionDataSO> mediumQuestionsDataList;
    [SerializeField] private List<QuestionDataSO> hardQuestionsDataList;
    private int easyQuestionsCount = 10;
    private int mediumQuestionsCount = 5;
    private int hardQuestionsCount = 5;
    [SerializeField] private GameObject prefabQuestionOneRightAnswer;
    [SerializeField] private GameObject prefabQuestionTwoRightAnswer;

    [SerializeField] private List<GameObject> questions;

    private void Awake()
    {
        for (int i = 0; i < easyQuestionsCount; i++)
        {
            if (i >= easyQuestionsDataList.Count || easyQuestionsDataList[i] == null)
            {
                print("Not Enough Questions");
                break;
            }
            int randomElementNumber = Random.Range(0, easyQuestionsDataList.Count);//будем спавнить 10 случайных элементов из списка
            InstantiatePrefab(randomElementNumber, "Easy", easyQuestionsDataList, i);
        }
        for (int i = 0; i < mediumQuestionsCount; i++)
        {
            if (i >= mediumQuestionsDataList.Count || mediumQuestionsDataList[i] == null)
            {
                print("Not Enough Questions");
                break;
            }
            int randomElementNumber = Random.Range(0, mediumQuestionsDataList.Count);
            InstantiatePrefab(randomElementNumber, "Medium", mediumQuestionsDataList, i);
        }
        for (int i = 0; i < hardQuestionsCount; i++)
        {
            if (i >= hardQuestionsDataList.Count || hardQuestionsDataList[i] == null)
            {
                print("Not Enough Questions");
                break;
            }
            int randomElementNumber = Random.Range(0, hardQuestionsDataList.Count);
            InstantiatePrefab(randomElementNumber, "Hard", hardQuestionsDataList, i);
        }
        //После создания всех вопросов
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            questions.Add(gameObject.transform.GetChild(i).gameObject);
        }
        ShuffleQuestions();
        for (int i = 0; i < questions.Count; i++)//shuffle for answers
        {
            if (questions[i].GetComponent<Question>() != null)
            {
                questions[i].GetComponent<Question>().ShuffleAnswers();
            }
            else print("Error in questions list. Current element:" + questions[i]);
        }
    }

    private void InstantiatePrefab(int elementNumber, string nameForElement, List<QuestionDataSO> QuestionsDataList, int iterator)
    {
        GameObject prefab = prefabQuestionOneRightAnswer;// default
        switch (QuestionsDataList[elementNumber].questionType)
        {
            case "QuestionOneRightAnswer":
                prefab = prefabQuestionOneRightAnswer;
            break;
            case "QuestionTwoRightAnswer":
                prefab = prefabQuestionTwoRightAnswer;
            break;
            default:
                print("Error in prefab naming in Scriptable Object element:" + nameForElement + elementNumber);
            break;
        }

        GameObject childGameObject = Instantiate(prefab, gameObject.transform);
        childGameObject.name = nameForElement + iterator;
        childGameObject.GetComponent<Question>().SetQuestionDataFromSO(QuestionsDataList[elementNumber]);
    }

    public void ChangeInteractabilityForTogglesInQuestions(bool IsInteractable)
    {
        foreach (GameObject question in questions)
        {
            if (question.GetComponent<Question>() != null) question.GetComponent<Question>().ChangeInteractabilityForToggles(IsInteractable);
        }
    }

    public void ShuffleQuestions()
    {
        for (int i = 0; i < questions.Count; i++)
        {
            GameObject temp = questions[i];
            int randomIndex = Random.Range(i, questions.Count);
            questions[i] = questions[randomIndex];
            questions[randomIndex] = temp;
        }

        // Применение перемешанного порядка к иерархии
        for (int i = 0; i < questions.Count; i++)
        {
            questions[i].transform.SetSiblingIndex(i);
            questions[i].GetComponent<Question>().ShuffleAnswers();
        }
    }
}
