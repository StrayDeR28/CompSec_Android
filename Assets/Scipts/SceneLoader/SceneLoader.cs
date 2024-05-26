using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private ScenesEnum LoadNextScene = ScenesEnum.MainScene;
    private string sceneName = "MainScene";
    [SerializeField] private enum ScenesEnum { None = 0, MainScene = 1, TestScene = 2, TempScene = 3 };

    public void LoadScene()
    {
        switch (LoadNextScene)
        {
            case ScenesEnum.MainScene:
                sceneName = "MainScene";
                SceneManager.LoadScene(sceneName);
            break;
            case ScenesEnum.TestScene:
                sceneName = "TestScene";
                SceneManager.LoadScene(sceneName);
            break;
            case ScenesEnum.TempScene:
                sceneName = "TempScene";
                SceneManager.LoadScene(sceneName);
            break;
            default: break;
        }
    }
}
