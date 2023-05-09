using System;
using Delivery;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth = 100f;
    [SerializeField] private float _heroDamage = 5;
    [SerializeField] private float _changeSpeed;
    [SerializeField] private float _startSpeed = 5f;
    private float _currentspeed = 5f;

    public float CurrentSpeed;
    public float CurrentHeroDamage { get; set; }
    public float MaxHealth { get; set; } 
    public float CurrentHealth { get; set; }
    public float ChangeSpeed { get; private set; }
    public event Action<float> OnMaxHealthChanged;
    private Trader _trader;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _scale;
    [SerializeField] private Vector3 _originalScale;
    private InputController _inputController;
        
        
    [SerializeField] private Transform _spawnPoint;


    private InventoryManager _inventoryManager;
    private bool _canDeliver = false;

    private void Start()
    {
        CurrentSpeed = _startSpeed;

        CurrentHeroDamage = _heroDamage;
        MaxHealth = _maxHealth;
        CurrentHealth = _currentHealth;
        OnMaxHealthChanged?.Invoke(MaxHealth);
            
        _inventoryManager = InventoryManager.instance;

        _trader = FindObjectOfType<Trader>();
            
            
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _inputController = FindObjectOfType<InputController>();

    }

    private void Update()
    {
        //CurrentSpeed = _currentspeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_inventoryManager.inventoryItems.Count > 0)
            {
                string ItemTag = _trader.ItemPrefab.tag;
                GameObject item = _inventoryManager.inventoryItems[0];
                _inventoryManager.RemoveItem(item);
                GameObject _itemObject = _trader.ItemPrefab;
                Instantiate(_itemObject, transform.position, Quaternion.identity);
                PaintTheHero(tag);
            }
            else if (_canDeliver)
            {
                string ItemTag = _trader.ItemPrefab.tag;
                GameObject _itemObject = GameObject.FindWithTag(ItemTag);
                _inventoryManager.AddItem(_itemObject);
                Destroy(_itemObject);
                Debug.Log("hhhhhhhhhhhhhhhh");
                PaintTheHero(ItemTag);
            }
        }
    }

    public void PaintTheHero(string ItemTag)
    {
        switch (ItemTag)
        {
            case "MainHero":
                Debug.Log("Обычный");
                _spriteRenderer.color = new Color(1f, 1f, 1f);
                _spriteRenderer.transform.localScale = _originalScale;
                CurrentSpeed = _startSpeed;
                break;
            case "Item1":
                Debug.Log("Зеленый");
                _spriteRenderer.color = new Color(0.2880f, 1f, 0.1745f);
                _spriteRenderer.transform.localScale *= (_scale / 100 + 1);
                ChangeSpeedHero(_changeSpeed);
                break;
            case "Item2":
                Debug.Log("Оранжевый");
                _spriteRenderer.color = new Color(1f, 0.78f, 0f);
                _spriteRenderer.transform.localScale *= (_scale / 100 + 1);
                ChangeSpeedHero(_changeSpeed);
                break;
            case "Item3":
                Debug.Log("Голубой");
                _spriteRenderer.color = new Color(0f, 0.8832f, 1f);
                _spriteRenderer.transform.localScale *= (_scale / 100 + 1);
                ChangeSpeedHero(_changeSpeed);
                break;
            default:
                return;
        }
    }
        
    public void ChangeSpeedHero(float ChangeSpeed)
    {
        CurrentSpeed /= ChangeSpeed / 100 + 1;
    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item1") || other.CompareTag("Item2") || other.CompareTag("Item3"))
        {
            _canDeliver = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item1") || other.CompareTag("Item2") || other.CompareTag("Item3"))
        {
            _canDeliver = false;
        }
    }
        
    public void HeroDie()
    {
        gameObject.transform.position = _spawnPoint.transform.position;
        CurrentHealth = MaxHealth;
    }
        
}