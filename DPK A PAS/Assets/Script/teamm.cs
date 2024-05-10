using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamm : MonoBehaviour
{

    [SerializeField] GameObject gameObj;

    void Start()
    {
        
    }

    public void MeetTheTeam(){
        gameObj.SetActive(true);
    }

    public void backButton(){
        gameObj.SetActive(false);
    }

    void Update()
    {
        
    }
}
