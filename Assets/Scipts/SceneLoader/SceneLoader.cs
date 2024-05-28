using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private ScenesEnum LoadNextScene = ScenesEnum.MainScene;
    private string sceneName = "Menu";
    [SerializeField] private enum ScenesEnum { None = 0, MainScene = 1, SceneForTest = 2, Book = 3 };

    public void LoadScene()
    {
        switch (LoadNextScene)
        {
            case ScenesEnum.MainScene:
                sceneName = "Menu";
                SceneManager.LoadScene(sceneName);
            break;
            case ScenesEnum.SceneForTest:
                sceneName = "SceneForTest";
                SceneManager.LoadScene(sceneName);
            break;
            case ScenesEnum.Book:
                sceneName = "Book";
                SceneManager.LoadScene(sceneName);
            break;
            default: break;
        }
    }
}
