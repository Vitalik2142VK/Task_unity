using Unity.VisualScripting;
using UnityEngine;

public class PointSpawn : MonoBehaviour
{
    [SerializeField] private Enemy _spawnEnemy;
    [SerializeField] private Vector3 _directionSpawnObject;
    [SerializeField] private Quaternion _spawnObjectRotation = Quaternion.Euler(0,0,0);

    private Vector3 _spawnObjectPosition;

    public Vector3 PointMovement => _directionSpawnObject;

    public void SpawnEnemy()
    {
        _spawnObjectPosition = transform.position;

        Enemy enemy = Instantiate(_spawnEnemy, _spawnObjectPosition, _spawnObjectRotation);
        var movement = enemy.AddComponent<Movement>();
        movement.Direction = _directionSpawnObject;
    }
}
