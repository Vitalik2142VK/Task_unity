using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [SerializeField] private Waypoint[] _allWaypoints;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isLooped;

    private Queue<Waypoint> _waypoints;
    private Waypoint _currentWaypoint;

    private void Start()
    {
        _waypoints = new Queue<Waypoint>(_allWaypoints);

        GetNextWaypoint();
    }

    private void Update()
    {
        if (_currentWaypoint != null)
        {            
            MoveToWaypoint();
        }
    }

    public void GetNextWaypoint()
    {
        if (_waypoints.Count != 0)
            _currentWaypoint = _waypoints.Dequeue();
        else 
            _currentWaypoint = null;

        if (_isLooped)
            _waypoints.Enqueue(_currentWaypoint);
    }

    private void MoveToWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.transform.position, _speed * Time.deltaTime);
    }
}
