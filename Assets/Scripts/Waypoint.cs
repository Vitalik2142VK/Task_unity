using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TargetMovement movement = other.GetComponent<TargetMovement>();

        if (movement is not null)
            movement.GetNextWaypoint();
    }
}
