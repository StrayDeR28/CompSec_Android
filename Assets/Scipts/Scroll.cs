using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    [SerializeField] ScrollRect scrollRect;

    // Start is called before the first frame update
    void Awake()
    {
        scrollRect = gameObject.GetComponent<ScrollRect>();
        scrollRect.verticalNormalizedPosition = 1f;
    }

    void OnEnable()
    {
        scrollRect.verticalNormalizedPosition = 1f;
    }
}
