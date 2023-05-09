using UnityEngine;

public class EnemyMoveming : MonoBehaviour
{
    [SerializeField] private string followTag = "Player"; 
    [SerializeField] private float moveSpeed = 5f;
    private Transform _target;
    
    void FixedUpdate()
    {
        GameObject followObject = GameObject.FindWithTag(followTag);
        if (followObject != null)
        {
            _target = followObject.transform;
        }
        else
        {
            Debug.LogWarning("Could not find object with tag " + followTag + " to follow.");
        }
    }
    void Update()
    {
        
        if (_target != null)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}