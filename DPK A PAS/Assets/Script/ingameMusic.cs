using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingameMusic : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public AudioClip backgroundMusic;  
    public List<string> destroyScene = new List<string>();

    void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.Play();
        destroyScene.Add("start scene");
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}
