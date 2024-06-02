using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    enum Chapter { Malware, Social, Physic }

    [SerializeField] ScrollRect scrollRect;
    [SerializeField] int Index;
    // [SerializeField] Chapter chapter;
    [SerializeField] string chapter;
    float time;

    // Start is called before the first frame update
    void Awake()
    {
        scrollRect = gameObject.GetComponent<ScrollRect>();
        scrollRect.verticalNormalizedPosition = 1f;
    }

    void OnEnable()
    {
        scrollRect.verticalNormalizedPosition = 1f;
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        float pos = scrollRect.verticalNormalizedPosition;
        if (pos < 0.05f && time > 3)
        {
            int data = PlayerPrefs.GetInt(chapter);
            int value = 1 << Index;
            data |= value;
            PlayerPrefs.SetInt(chapter, data);
            // print(chapter + ' ' + PlayerPrefs.GetInt(chapter));
        }
    }
}
