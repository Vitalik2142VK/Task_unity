using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private EnemySpawnPoint[] _points;
    [SerializeField] private float _delay = 2;
    [SerializeField] private bool _isSpawnWork = false;

    private WaitForSeconds _wait;
    private int _indexPointSpawn;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (_isSpawnWork)
        {
            _indexPointSpawn = Random.Range(0, _points.Length);
            _points[_indexPointSpawn].SpawnEnemy();

            yield return _wait;
        }
    }
}
