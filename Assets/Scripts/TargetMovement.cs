using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private const int _indexDefault = -1;

    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isLooped;

    private Waypoint _currentWaypoint;
    private int _currentIndexWaypoint = _indexDefault;
    private bool _isReachedPoint = false;

    private void Start()
    {
        if (_waypoints.Length != 0)
            SpecifyNextWaypoint();
        else
            _currentIndexWaypoint = _indexDefault;
    }

    private void Update()
    {
        if (_currentIndexWaypoint != _indexDefault)
        {            
            MoveToWaypoint();

            if (_isReachedPoint)
                SpecifyNextWaypoint();
        }
    }

    private void MoveToWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.transform.position, _speed * Time.deltaTime);
    }

    private void SpecifyNextWaypoint()
    {
        if (_currentIndexWaypoint < _waypoints.Length)
        {
            _currentIndexWaypoint++;
        }
        else if (_isLooped)
        {
            _currentIndexWaypoint = 0;
        }
        else
        {
            _currentIndexWaypoint = _indexDefault;

            return;
        }

        _currentWaypoint = _waypoints[_currentIndexWaypoint];

        _isReachedPoint = false;
    }

    public void ReachedPoint()
    {
        _isReachedPoint = true;
    }
}
