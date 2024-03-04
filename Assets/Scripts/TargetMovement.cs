using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private const int IndexDefault = -1;

    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _distanceActivationPoint = 2;
    [SerializeField] private bool _isLooped = true;

    private int _currentIndexWaypoint = IndexDefault;

    private void Start()
    {
        if (_waypoints.Length != 0)
            SpecifyNextWaypoint();
        else
            _currentIndexWaypoint = IndexDefault;
    }

    private void Update()
    {
        if (_currentIndexWaypoint != IndexDefault)
        {
            Transform point = _waypoints[_currentIndexWaypoint].transform;
            float distanceToPoint = Vector3.Distance(transform.position, point.position);

            transform.position = Vector3.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

            if (distanceToPoint < _distanceActivationPoint)
            {
                SpecifyNextWaypoint();
            }
        }
    }

    private void SpecifyNextWaypoint()
    {
        _currentIndexWaypoint++;

        if (_currentIndexWaypoint == _waypoints.Length)
        {
            if (_isLooped)
                _currentIndexWaypoint = 0;
            else
                _currentIndexWaypoint = IndexDefault;
        }
    }
}
