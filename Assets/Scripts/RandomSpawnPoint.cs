using System.Collections;
using UnityEngine;

public class RandomSpawnPoint : MonoBehaviour
{
    [SerializeField] private PointSpawn[] _points;
    [SerializeField] private float _delay = 2;
    [SerializeField] private bool _isBeginSpawn = false;

    private WaitForSeconds _wait;
    private int _indexPointSpawn;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        StartCoroutine(CroutineSpawn());
    }

    private IEnumerator CroutineSpawn()
    {
        while (_isBeginSpawn)
        {
            _indexPointSpawn = Random.Range(0, _points.Length);


            Debug.Log($"Текущий индекс - {_indexPointSpawn}, мах ел - {_points.Length}");

            _points[_indexPointSpawn].SpawnEnemy();

            yield return _wait;
        }
    }
}
