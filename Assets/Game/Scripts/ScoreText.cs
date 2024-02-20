using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text textContent;
    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        textContent.text = "Score: 0" + "\n" + "HighScore: " + PlayerPrefs.GetInt("2SCORE", 0);
    }

    public void UpdateScoreText()
    {
        textContent.text = "Score: " + GameManager.instance.score + "\n" + "HighScore: " + PlayerPrefs.GetInt("2SCORE", 0);
    }
}
