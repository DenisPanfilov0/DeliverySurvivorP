using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _enemyDamage;
    [SerializeField] private float _enemyHealth;
    [SerializeField] private Animator _animator;

    //private float EnemyHealth;
    private HeroController _heroController;
    private Weapon _weapon;

    private SpawnEnemy _spawnEnemy;
    //[SerializeField] private TextMeshProUGUI _damageText;
    //[SerializeField] private Text _damageText;

    private void Start()
    {
        _weapon = FindObjectOfType<Weapon>();
        //EnemyHealth = _enemyHealth;
        _spawnEnemy = FindObjectOfType<SpawnEnemy>();
        _heroController = FindObjectOfType<HeroController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainHero"))
        {
            TakeDamageHero(_enemyDamage);
        }
    }
        
    private void TakeDamageHero(float damage)
    {
        _heroController.CurrentHealth -= damage;
        
        if (_heroController.CurrentHealth <= 0)
        {
            _heroController.HeroDie();
            var ObjectBonus1 = GameObject.FindGameObjectsWithTag ("Enemy");
            for (int i=0; i<100; i++) 
            {
                Destroy (ObjectBonus1[i]);
                _spawnEnemy._currentMonsters--;
            }

        }
    }
        
        
        
    private void Die()
    {
        Destroy(gameObject);
        Balance.Instance._balanceValue += 1f;
        Score.Instance._scoreValue += 1;
        _spawnEnemy._currentMonsters--;
    }
        
    public void TakeDamageEnemy(float damage/*, Animator animator*/)
    {
        //_damageText.text = "-" + damage.ToString();
        _enemyHealth -= damage;
        if (_enemyHealth <= 0)
        {
            Die();
        }
        
    }
        
        
}