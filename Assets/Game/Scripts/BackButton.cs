using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] Button buttonBack;
    // Start is called before the first frame update
    void Start()
    {
        
        buttonBack.onClick.AddListener(() =>
        {
            GameManager.instance.HideCanvasMenu();
            GameManager.instance.SetButtonPlay();
            GameManager.instance.HideCanvasBack();
        });
    }
}
