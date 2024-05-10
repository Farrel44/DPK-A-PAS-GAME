using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    public DoorFinish Thanks;
    void Start() {
        Thanks = FindAnyObjectByType<DoorFinish>();
        Thanks.ending.SetActive(false);
        
    }
    public GameObject meetTheTeam;
    // Start is called before the first frame update
    public void StartGame (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MettTheTeam(){
        meetTheTeam.SetActive(true);
    }

    public void QuitGame (){
        Debug.Log("Quit");
        Application.Quit();
    }
}
