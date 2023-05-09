using TMPro;
using UnityEngine;
/// <summary>
/// класс реализующий баланс игрока в синглтоне
/// </summary>
public class Balance : MonoBehaviour
{
    [SerializeField] public float _balanceValue;
    [SerializeField] private TextMeshProUGUI _currentBalanceText;
    private static Balance _instance;

    public static Balance Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Balance>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(Balance).Name;
                    _instance = obj.AddComponent<Balance>();
                }
            }
            return _instance;
        }
    }
    //todo Поискать позже более лаконичное решение для приватной установки
    public float BalanceValue
    {
        get { return _balanceValue; }
        set { _balanceValue = value; }
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
        _currentBalanceText.text = _balanceValue.ToString();
    }
}