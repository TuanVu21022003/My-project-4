using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager instance => _instance;
    private bool isPaused = false;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private GameObject _player = null;
    [SerializeField] private GameObject _map = null;
    public GameObject player => _player;
    public GameObject map => _map;
    [SerializeField] private int _score, _highsore;
    public int score  => _score;
    public int highsore => _highsore;
    [SerializeField] private ScoreText scoreText;
    [SerializeField] GameObject canvasPlay;
    [SerializeField] GameObject canvasMenu;
    [SerializeField] GameObject canvasBack;
    [SerializeField] GameObject canvasOpenMenu;
    private bool _isOpenMenu = true;
    public bool isOpenMenu => _isOpenMenu;
    [SerializeField] GameObject canvasScore;

    private int _timeEnemyAppear;
    public int timeEnemyAppear;
    private Vector2 newPos;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            return;
        }
        if (_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID()) { }
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        HideCanvasBack();
        HideCanvasMenu();
        HideCanvasOpenMenu();
        HideCanvasScore();
        _highsore = PlayerPrefs.GetInt("2SCORE", highsore);
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f; // Dừng thời gian trong game
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Tiếp tục thời gian trong game
        isPaused = false;
    }

    public void SetCheckOpenMenu()
    {
        _isOpenMenu = !_isOpenMenu;
    }

    public void SetTimeEnemyAppear(int time)
    {
        timeEnemyAppear = time;
    }

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }

    public void SetMap(GameObject map)
    {
        _map = map;
    }

    // Update is called once per frame

    public void SetEnemy()
    {
        newPos = Vector2.zero;
        Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Debug.Log(screenSize);
        List<Vector2> newPosList = new List<Vector2>();
        newPosList.Add(new Vector2(-screenSize.x, -screenSize.y));
        newPosList.Add(new Vector2(-screenSize.x, screenSize.y));
        newPosList.Add(new Vector2(screenSize.x, -screenSize.y));
        newPosList.Add(new Vector2(screenSize.x, screenSize.y));
        newPos = newPosList[Random.Range(0, 4)];
        GameObject enemy = ObjectPooling.instance.getObject(enemyPrefab.gameObject);
        enemy.transform.position = newPos;
        enemy.transform.rotation = Quaternion.identity;
        enemy.SetActive(true);

    }

    public void RepeatEnemy()
    {
        InvokeRepeating(nameof(SetEnemy), 3, timeEnemyAppear);
    }

    public void StopRepeat()
    {
        CancelInvoke(nameof(SetEnemy));
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

    public void ResetScore()
    {
        _score = 0;
    }

    public void ResetScoreText()
    {
        scoreText.OnInit();
    }
    public void SetScoreText()
    {
        scoreText.UpdateScoreText();
    }

    public void SetButtonPlay()
    {
        canvasPlay.SetActive(true);
    }
    public void HideButtonPlay()
    {
        canvasPlay.SetActive(false);
    }
    public void SetCanvasMenu()
    {
        canvasMenu.SetActive(true);
    }

    public void HideCanvasMenu()
    {
        canvasMenu.SetActive(false);
    }
    public void SetCanvasBack()
    {
        canvasBack.SetActive(true);
    }

    public void HideCanvasBack()
    {
        canvasBack.SetActive(false);
    }

    public void SetCanvasOpenMenu()
    {
        canvasOpenMenu.SetActive(true);
    }

    public void HideCanvasOpenMenu()
    {
        canvasOpenMenu.SetActive(false);
    }

    public void SetCanvasScore()
    {
        canvasScore.SetActive(true);
    }

    public void HideCanvasScore()
    {
        canvasScore.SetActive(false);
    }

}
