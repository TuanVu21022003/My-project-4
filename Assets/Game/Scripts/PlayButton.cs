using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] Button buttonPlay;
    // Start is called before the first frame update
    void Start()
    {

        buttonPlay.onClick.AddListener(() =>
        {
            GameManager.instance.SetCanvasMenu();
            GameManager.instance.HideButtonPlay();
            GameManager.instance.SetCanvasBack();
        });
    }
}
