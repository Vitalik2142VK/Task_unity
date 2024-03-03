using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<MovementToPoints>().GetNextWaypoint();
    }
}
