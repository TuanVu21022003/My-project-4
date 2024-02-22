using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSelectionUI : MonoBehaviour
{
    [SerializeField] LevelItemUI levelItemPrefab;
    [SerializeField] Transform parentPosition;
    [SerializeField] LevelOS levelData;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject mapPrefab;

    // Start is called before the first frame update
    void Start()
    {
        OnDespawnSetLevelList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDespawnSetLevelItem(Sprite spriteImage, string textIndex, Sprite spriteMap)
    {
        LevelItemUI levelItemObject = Instantiate(levelItemPrefab, parentPosition);
        levelItemObject.OnInit(spriteImage, textIndex, spriteMap, OnHandleUpdateLevelEnemy);
    }

    public void OnDespawnSetLevelList()
    {
        for (int i = 0; i < levelData.list.Count; i++)
        {
            OnDespawnSetLevelItem(levelData.list[i].levelSprite, levelData.list[i].levelIndex.ToString(), levelData.list[i].levelMap);
        }
    }


    public void OnHandleUpdateLevelEnemy(string textIndex, Sprite spriteImage, Sprite spriteMap)
    {
        if(GameManager.instance.player == null)
        {

            GameObject p = Instantiate(playerPrefab);
            GameManager.instance.SetPlayer(p);
        }
        if (GameManager.instance.map == null)
        {

            GameObject m = Instantiate(mapPrefab);
            GameManager.instance.SetMap(m);
        }
        GameManager.instance.player.GetComponent<Player>().SetSprite(spriteImage);
        GameManager.instance.map.GetComponent<Map>().SetBackground(spriteMap);
        Debug.Log(textIndex);
        GameManager.instance.StopRepeat();
        GameManager.instance.SetTimeEnemyAppear(10 - int.Parse(textIndex) * 2);
        GameManager.instance.RepeatEnemy();
        GameManager.instance.HideCanvasMenu();
        GameManager.instance.HideCanvasBack();
        GameManager.instance.SetCanvasOpenMenu();
        GameManager.instance.SetCheckOpenMenu();
        GameManager.instance.SetCanvasScore();
        GameManager.instance.ResetScore();
        GameManager.instance.ResetScoreText();
        GameManager.instance.ResumeGame();
    }

}
