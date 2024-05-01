using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgmScrpit : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip background;

    public List<string> destroyScene = new List<string>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

        destroyScene.Add("level 1");
        destroyScene.Add("level 2");
        destroyScene.Add("level 3");
        destroyScene.Add("level 4");
        destroyScene.Add("level 5");
    }

    void Update()
    {
        foreach (string sceneName in destroyScene)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                Destroy(gameObject);
                break;
            }
        }
    }
}
