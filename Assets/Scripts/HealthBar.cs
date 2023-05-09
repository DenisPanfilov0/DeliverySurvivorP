using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private HeroController _heroController;
    [SerializeField] private Slider _sliderHelth;
    [SerializeField] private float fillSpeed = 5f;
    [SerializeField] private TextMeshProUGUI _hpPercentText;
        
    private void Start()
    {
        _heroController = FindObjectOfType<HeroController>();
        _heroController.OnMaxHealthChanged += UpdateMaxHealth;
            
    }

    private void Update()
    {
        _sliderHelth.maxValue = _heroController.MaxHealth;
        //_hpPercentText.text = _sliderHelth.value.ToString() + "/" + _sliderHelth.value.ToString();
        _hpPercentText.text = _sliderHelth.value.ToString() + "/" + _heroController.MaxHealth.ToString();
        _sliderHelth.value = _heroController.CurrentHealth;
        _sliderHelth.value = Mathf.Lerp(_sliderHelth.value, _heroController.CurrentHealth,  fillSpeed * Time.deltaTime);
    }
        
    private void UpdateMaxHealth(float newMaxHealth)
    {
        _sliderHelth.maxValue = newMaxHealth;
    }
}