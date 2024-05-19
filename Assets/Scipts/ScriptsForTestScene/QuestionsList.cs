using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsList : MonoBehaviour
{
    [SerializeField] private List<Question> questions;

    public void ChangeInteractabilityForTogglesInQuestions(bool IsInteractable)
    {
        foreach (Question question in questions)
        {
            question.ChangeInteractabilityForToggles(IsInteractable);
        }
    }
}
