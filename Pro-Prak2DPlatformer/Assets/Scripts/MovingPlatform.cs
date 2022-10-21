using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _checkDistance = 0.05f;

    private Transform _targetWaypoint;
    private int _currentWaypointIndex = 0;

    void Start()
    {
        _targetWaypoint = _waypoints[0];

    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _targetWaypoint.position,
            _speed * Time.deltaTime
            );

        if (Vector2.Distance(transform.position, _targetWaypoint.position) < _checkDistance)
        {
            _targetWaypoint = GetNextWaypoint();
        }
    }

    private Transform GetNextWaypoint()
    {
        _currentWaypointIndex++;
        if (_currentWaypointIndex >= _waypoints.Length)
        {
            _currentWaypointIndex = 0;
        }

        return _waypoints[_currentWaypointIndex];
    }
}
