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
        List<QuestionDataSO> currentQuestionList = new List<QuestionDataSO>(easyQuestionsDataList);
        for (int i = 0; i < easyQuestionsCount; i++)
        {
            if (currentQuestionList.Count == 0)
            {
                print("Not Enough Questions");
                break;
            }
            int randomElementNumber = Random.Range(0, currentQuestionList.Count);//будем спавнить 10 случайных элементов из списка
            InstantiatePrefab(randomElementNumber, "Easy", currentQuestionList, i);
            currentQuestionList.RemoveAt(randomElementNumber);
        }

        currentQuestionList = new List<QuestionDataSO>(mediumQuestionsDataList);
        for (int i = 0; i < mediumQuestionsCount; i++)
        {
            if (currentQuestionList.Count == 0)
            {
                print("Not Enough Questions");
                break;
            }
            int randomElementNumber = Random.Range(0, currentQuestionList.Count);
            InstantiatePrefab(randomElementNumber, "Medium", currentQuestionList, i);
            currentQuestionList.RemoveAt(randomElementNumber);
        }

        currentQuestionList = new List<QuestionDataSO>(hardQuestionsDataList);
        for (int i = 0; i < hardQuestionsCount; i++)
        {
            if (currentQuestionList.Count == 0)
            {
                print("Not Enough Questions");
                break;
            }
            int randomElementNumber = Random.Range(0, currentQuestionList.Count);
            InstantiatePrefab(randomElementNumber, "Hard", currentQuestionList, i);
            currentQuestionList.RemoveAt(randomElementNumber);
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
