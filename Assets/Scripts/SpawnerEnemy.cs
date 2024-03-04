using Unity.VisualScripting;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _prefab;
    [SerializeField] private Target _targetForEnemy;
    [SerializeField] private Quaternion _spawnRotation = Quaternion.Euler(0,0,0);

    private Vector3 _spawnPosition;

    private void Start()
    {
        _spawnPosition = transform.position;

        float heightEnemy = _prefab.transform.localScale.y;

        if (transform.position.y < heightEnemy)
        {
            _spawnPosition.y = heightEnemy;
        }
    }

    public void SpawnEnemy()
    {
        EnemyMovement enemy = Instantiate(_prefab, _spawnPosition, _spawnRotation);
        enemy.SetTarget(_targetForEnemy);
    }
}
