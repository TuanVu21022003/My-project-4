using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenuButton : MonoBehaviour
{
    [SerializeField] Button buttonOpen;
    // Start is called before the first frame update
    void Start()
    {

        buttonOpen.onClick.AddListener(() =>
        {
            if(!GameManager.instance.isOpenMenu)
            {
                GameManager.instance.HideCanvasMenu();
                GameManager.instance.ResumeGame();
            }
            else
            {
                GameManager.instance.SetCanvasMenu();
                GameManager.instance.PauseTheGame();
            }
            GameManager.instance.SetCheckOpenMenu();
        });
    }

}
