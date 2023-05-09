using TMPro;
using UnityEngine;
/// <summary>
/// класс реализующий баланс игрока в синглтоне
/// </summary>
public class Score : MonoBehaviour
{
    [SerializeField] public float _scoreValue;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    private static Score _instance;

    public static Score Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Score>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(Score).Name;
                    _instance = obj.AddComponent<Score>();
                }
            }
            return _instance;
        }
    }
    //todo Поискать позже более лаконичное решение для приватной установки
    public float ScoreValue
    {
        get { return _scoreValue; }
        set { _scoreValue = value; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        _currentScoreText.text = _scoreValue.ToString();
    }
}