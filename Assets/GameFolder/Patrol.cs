using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints;
    private int _currentWaypointIndex;
    private float speed = 3f;
    private float waitTime = 1f;
    private float waitCounter = 0f;

    private bool _isWaiting = false;
    private void Update()
    {
        if (_isWaiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter < waitTime)
                return;
            _isWaiting = false;
        }

        Transform wp = waypoints[_currentWaypointIndex];
        if (Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            transform.position = wp.position;
            waitCounter  = 0f;
            _isWaiting = true;

            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);
            transform.LookAt(wp.position);
        }
    }

}
