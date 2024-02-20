using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager instance => _instance;

    // Start is called before the first frame update
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private GameObject _player;
    public GameObject player => _player;
    [SerializeField] private int _score, _highsore;
    public int score => _score;
    public int highsore => _highsore;

    [SerializeField] private ScoreText scoreText;

    
    private Vector2 newPos;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            return;
        } 
        if(_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID()) { }
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating(nameof(SetEnemy), 3, 5);
        _highsore = PlayerPrefs.GetInt("2SCORE", highsore);
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
        GameObject enemy = EnemyPool.instance.GetEnemy();
        enemy.transform.position = newPos;
        enemy.transform.rotation = Quaternion.identity;
        enemy.SetActive(true);

    }

    public void SetScore(int score)
    {
        this._score += score;
        if(_highsore < _score)
        {
            _highsore = _score;
        }
        PlayerPrefs.SetInt("2SCORE", _highsore);
    }

    public void SetScoreText()
    {
        scoreText.UpdateScoreText();
    }
}
