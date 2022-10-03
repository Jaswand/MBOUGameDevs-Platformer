using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private SpriteRenderer _renderer;
    [SerializeField] private float speed = 2f;
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (currentWaypointIndex == 0)
        {
            _renderer.flipX = false;
        }
        else if (currentWaypointIndex == 1)
        {
            _renderer.flipX = true;
        }

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
