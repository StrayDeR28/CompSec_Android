using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField] InputHandler handler;
    [SerializeField] List<Info> scores;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform area;

    [SerializeField] List<Sprite> sprites;

    void OnEnable()
    {
        scores = handler.entries;
        for (int i = scores.Count - 1; i >= 0; i--)
        {
            GameObject inst = prefab;
            switch (scores[i].Score)
            {
                case >= 34:
                    inst.transform.GetChild(0).GetComponent<Image>().sprite = sprites[3];
                    break;
                case >= 28:
                    inst.transform.GetChild(0).GetComponent<Image>().sprite = sprites[2];
                    break;
                case >= 20:
                    inst.transform.GetChild(0).GetComponent<Image>().sprite = sprites[1];
                    break;
                case < 20:
                    inst.transform.GetChild(0).GetComponent<Image>().sprite = sprites[0];
                    break;
            }
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