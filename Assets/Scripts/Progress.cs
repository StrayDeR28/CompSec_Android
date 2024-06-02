using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Progress : MonoBehaviour
{
    [SerializeField] InputHandler handler;
    [SerializeField] List<Info> scores;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform area;

    void OnEnable()
    {
        scores = handler.entries;
        for (int i = scores.Count - 1; i >= 0; i--)
        {
            GameObject inst = prefab;
            inst.GetComponent<BuildScore>().SetData(scores[i]);
            Instantiate(inst, area);
        }
    }

    public void Clear()
    {
        while (area.transform.childCount > 0)
        {
            DestroyImmediate(area.transform.GetChild(0).gameObject);
        }
    }
}