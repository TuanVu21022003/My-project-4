using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelItemUI : MonoBehaviour
{
    [SerializeField] private Text textIndex;
    [SerializeField] private Image spriteImage;
    [SerializeField] private Button buttonLevel;
    public void OnInit(Sprite spriteImage, string textIndex, Sprite spriteMap, Action<string, Sprite, Sprite> buttonLevelClick)
    {
        this.textIndex.text = "Level " + textIndex;
        this.spriteImage.sprite = spriteImage;
        buttonLevel.onClick.AddListener(() =>
        {
            buttonLevelClick.Invoke(textIndex, spriteImage, spriteMap);
        });
    }
}
