using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public List<string> levelAccess = new List<string>();
    public int CurrentLevelIndex { get; private set; } // Properti untuk mengakses currentLevelIndex secara publik

    void Start()
    {
        levelAccess.Add("Level 2");
        levelAccess.Add("Level 3");
        levelAccess.Add("Level 4");
        levelAccess.Add("Level 5");

        StartCoroutine(LoadNextScene(levelAccess[0]));
    }

    IEnumerator LoadNextScene(string level)
    {
        yield return new WaitForSeconds(0.25f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        CurrentLevelIndex++;
        if (CurrentLevelIndex < levelAccess.Count)
        {
            StartCoroutine(LoadNextScene(levelAccess[CurrentLevelIndex]));
        }
    }
}
