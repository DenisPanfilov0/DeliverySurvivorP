using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float attackRate = 3f;
    public float CurrentDamage = 10f;
    public float colliderRadius = 1f;
    public LayerMask enemyLayer;
    //[SerializeField] private ParticleSystem _slashEffect;
    [SerializeField] private GameObject _slashEffect;
    [SerializeField] private Transform _parent;
    [SerializeField] private Animator _enemyTakeDamage;

    private HeroController _heroController;

    private float nextAttackTime = 0f;
    private bool isFacingRight = true;

    private EnemyController _enemyController;

    private void Start()
    {
        _heroController = FindObjectOfType<HeroController>();

        _enemyController = FindObjectOfType<EnemyController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        // Check if the character's facing direction needs to be updated
        if ((horizontal > 0 && !isFacingRight) || (horizontal < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
        
        
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
    
    public void Attack() 
    {
        
        if (isFacingRight)
        {
            GameObject slashEffect = Instantiate(_slashEffect, _parent.position, _slashEffect.transform.rotation, _parent);
            Destroy(slashEffect.gameObject, 0.5f);
        }
        else
        {
            GameObject slashEffect = Instantiate(_slashEffect, _parent.position, Quaternion.Euler(0, 180, 0) * _slashEffect.transform.rotation, _parent);
            Destroy(slashEffect.gameObject, 0.5f);
        }
        
        
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, colliderRadius);

        foreach(Collider2D hitCollider in hitColliders) {
            if(hitCollider.gameObject.CompareTag("Enemy")) {
                // Apply damage to enemy
                EnemyController enemy = hitCollider.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    Debug.Log("Take Damage");
                    enemy.TakeDamageEnemy(CurrentDamage);
                    //enemy.SetTrigger("AttackEnemy");
                }
            }
        }
        
    }
    
    private void OnDrawGizmos()
    {
        
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, colliderRadius);
        
    }

}