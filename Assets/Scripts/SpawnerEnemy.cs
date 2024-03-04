using Unity.VisualScripting;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _spawnEnemy;
    [SerializeField] private Target _targetForEnemy;
    [SerializeField] private Quaternion _spawnRotation = Quaternion.Euler(0,0,0);

    private Vector3 _spawnPosition;

    private void Start()
    {
        _spawnPosition = transform.position;

        float heightEnemy = _spawnEnemy.transform.localScale.y;

        if (transform.position.y < heightEnemy)
        {
            _spawnPosition.y = heightEnemy;
        }
    }

    public void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_spawnEnemy, _spawnPosition, _spawnRotation);
        var movement = enemy.AddComponent<EnemyMovement>();
        movement.SetTarget(_targetForEnemy);
    }
}
