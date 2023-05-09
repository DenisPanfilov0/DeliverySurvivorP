using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab; 
    [SerializeField] private int maxMonsters = 200; 
    [SerializeField] private float spawnRadiusMin = 10f;
    [SerializeField] private float spawnRadiusMax = 15f; 
    [SerializeField] private float spawnInterval = 5f; 
    //[SerializeField] private Transform _parentObject;
    [SerializeField] private Transform _hero;
    public float _currentMonsters = 0f; 
    private float _timeSinceLastSpawn = 0f; 
    

    void Update()
    {
        if (_currentMonsters < maxMonsters)
        {
            _timeSinceLastSpawn += Time.deltaTime;

            if (_timeSinceLastSpawn >= spawnInterval && _currentMonsters < maxMonsters)
            {
                Vector2 randomOffset = Random.insideUnitCircle.normalized * Random.Range(spawnRadiusMin, spawnRadiusMax);
                Vector3 spawnPosition = _hero.position + new Vector3(randomOffset.x, randomOffset.y, 0f);
                Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
                _currentMonsters++;
                _timeSinceLastSpawn = 0f;
            }
        }
    }

    public void DecreaseMonsters()
    {
        _currentMonsters--;
    }
}
