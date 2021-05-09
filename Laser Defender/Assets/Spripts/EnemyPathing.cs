using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // Type of the list is "Transform" because the only thing we need
    // from the waypoints is the position

    WaveConfig waveConfig;
    List<Transform> waypoints; // Waypoints for the enemy to follow
    int waypointIndex = 0; // Which way point am I currently working towards

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position; // Where we want to go
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime; // How fast we move
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++; // If we have reached the desired waypoint, move to the next one
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
