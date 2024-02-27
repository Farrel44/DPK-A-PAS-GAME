using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class levelSelection : MonoBehaviour
{
    public Text levelText;
    public int level;
    // Start is called before the first frame update
    void Start ()
    {
        levelText.text = level.ToString();
    }

    // Update is called once per frame
    public void LevelSelection ()
    {
        SceneManager.LoadScene("level " + level.ToString());
    }
}
