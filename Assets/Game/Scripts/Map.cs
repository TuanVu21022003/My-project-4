using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject mapBackground;

    public void SetBackground(Sprite spriteBackground)
    {
        mapBackground.GetComponent<SpriteRenderer>().sprite = spriteBackground;
    }
}
