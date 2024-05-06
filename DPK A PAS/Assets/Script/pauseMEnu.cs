using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMEnu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Pause");
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Resume");
    }

    public void Home(){
        SceneManager.LoadScene("Level Select");
        Time.timeScale = 1;
        Debug.Log("Home");
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Debug.Log("Restart");
    }


}
