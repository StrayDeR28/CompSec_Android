using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] string filename;

    public List<Info> entries = new();

    private void Start()
    {
        entries = FileHandler.ReadListFromJSON<Info>(filename);
    }

    public void AddNameToList()
    {

        entries.Add(new Info(GetValue("Malware"), GetValue("Social"), GetValue("Physic"), PlayerPrefs.GetInt("TotalPointsForTest1")));

        FileHandler.SaveToJSON(entries, filename);
    }

    int GetValue(string chapter)
    {
        // string[] chapters = {"Malware", "Social", "Physic"};
        // foreach (var chapter in chapters)
        int count = 0;
        int value = PlayerPrefs.GetInt(chapter);
        for (int i = 0; i < 5; i++)
        {
            if (((value >> i) & 1) == 1)
            {
                count++;
            }
        }
        return count;
    }
}