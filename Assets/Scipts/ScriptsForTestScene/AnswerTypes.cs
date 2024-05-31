using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerTypes : MonoBehaviour
{
    [SerializeField] private GameObject question;
    [SerializeField] private int pointsForAnswer;
    [SerializeField] private TMP_Text answerText;
    [SerializeField] public SummOfPointsSO summOfPointsForTest;
    [SerializeField] private TypesOfAnswer typesOfAnswer;
    [SerializeField] private Image checkmark;

    [SerializeField] private enum TypesOfAnswer { Add, Sub, None };

    private void Awake()
    {
        //answerText.text = gameObject.GetComponentInChildren<TMP_Text>().text;// скорее всего не получится из-за Instantiate, лучше вручную задать в префабе
        pointsForAnswer = question.GetComponent<Question>().rightAnswerCost;//тут дублирование...
        summOfPointsForTest = question.GetComponent<Question>().summOfPointsForTest;
    }

    public void SetDataFromSO(int pointsForAnswerFromSo, string answerTextFromSO, string typesOfAnswerFromSO)
    {
        pointsForAnswer = pointsForAnswerFromSo;
        answerText.text = answerTextFromSO;
        switch (typesOfAnswerFromSO)
        {
            case "None":
                typesOfAnswer = TypesOfAnswer.None; 
            break;
            case "Add":
                typesOfAnswer = TypesOfAnswer.Add;
            break;
            case "Sub":
                typesOfAnswer = TypesOfAnswer.Sub;
            break;
        }
    }

    public void CountPoints()
    {
        switch (typesOfAnswer)
        {
            case TypesOfAnswer.Add:
                if (gameObject.GetComponent<Toggle>().isOn) summOfPointsForTest.points += pointsForAnswer;
                else summOfPointsForTest.points -= pointsForAnswer;
            break;

            case TypesOfAnswer.Sub:
                if (gameObject.GetComponent<Toggle>().isOn) summOfPointsForTest.points -= pointsForAnswer;
                else summOfPointsForTest.points += pointsForAnswer;
            break;
            default:
            break;
        }
    }

    public void ChangeCheckmark(int typeOfQuestion, bool IsInteractable, Sprite defaultCircle, Sprite defaultArrow, Sprite crest, Sprite greenArrow, Sprite redCircle, Sprite greenCircle)
    {
        switch (IsInteractable)
        {
            case true:
                switch (typeOfQuestion)
                {
                    case 0:
                        if (gameObject.GetComponent<Toggle>().isOn) gameObject.GetComponent<Toggle>().isOn = false;
                        checkmark.sprite = defaultCircle;
                    break;
                    case 1:
                        if (gameObject.GetComponent<Toggle>().isOn) gameObject.GetComponent<Toggle>().isOn = false;
                        checkmark.sprite = defaultArrow;
                    break;
                }
                break;
            case false:
                switch (typeOfQuestion)
                {
                    case 0:
                        switch (typesOfAnswer)
                        {
                            case TypesOfAnswer.Add:
                                if (gameObject.GetComponent<Toggle>().isOn) checkmark.sprite = greenCircle;
                            break;
                            default:
                                if (gameObject.GetComponent<Toggle>().isOn) checkmark.sprite = redCircle;
                            break;
                        }
                        break;
                    case 1:
                        switch (typesOfAnswer)
                        {
                            case TypesOfAnswer.Add:
                                if (gameObject.GetComponent<Toggle>().isOn) checkmark.sprite = greenArrow;
                            break;
                            default:
                                if (gameObject.GetComponent<Toggle>().isOn) checkmark.sprite = crest;
                            break;
                        }
                    break;
                }
            break;
        }
            
    }
}
