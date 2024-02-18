using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAuto : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private GameObject _player;
    private Vector2 newPos;
    void Start()
    {
        InvokeRepeating(nameof(SetEnemy), 3, 5);
    }

    // Update is called once per frame

    public void SetEnemy()
    {
        newPos = Vector2.zero;
        Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        while (true)
        {
            newPos.x = Random.Range(-screenSize.x - 5, screenSize.x + 5);
            newPos.y = Random.Range(-screenSize.y - 5, screenSize.y + 5);
            if (newPos.x > screenSize.x || newPos.x < -screenSize.x || newPos.y < -screenSize.y || newPos.y > screenSize.y)
            {
                break;
            }
        }
        Instantiate(enemyPrefab, newPos, Quaternion.identity).SetTarget(_player);
    }
}
