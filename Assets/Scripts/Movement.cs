using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Waypoint[] _points;
    [SerializeField] private float _distanceActivationPoint = 2;
    [SerializeField] private float _speed;

    private int _currentIndexPoint = 0;

    private void Update()
    {
        Transform point = _points[_currentIndexPoint].transform;
        transform.position = Vector3.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, point.position);

        if (distance < _distanceActivationPoint)
            SpecifyNextPoint();
    }

    private void SpecifyNextPoint()
    {
        _currentIndexPoint++;

        if (_currentIndexPoint == _points.Length)
            _currentIndexPoint = 0;
    }
}
