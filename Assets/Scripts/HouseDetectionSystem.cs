using System;
using UnityEngine;

public class HouseDetectionSystem : MonoBehaviour
{
    private const int CountRobbersForActivation = 1;

    public event Action OnRobberEntered;
    public event Action OnRobberExited;

    private int _countRobbersInside = 0;

    private void OnTriggerEnter(Collider other)
    {
        _countRobbersInside++;

        if (other.GetComponent<Robber>() != null && _countRobbersInside == CountRobbersForActivation)
        {
            OnRobberEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _countRobbersInside--;

        if (other.GetComponent<Robber>() != null && _countRobbersInside < CountRobbersForActivation)
        {
            OnRobberExited?.Invoke();
        }
    }
}
