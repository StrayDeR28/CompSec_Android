using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsList : MonoBehaviour
{
    [SerializeField] private List<GameObject> questions;

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
