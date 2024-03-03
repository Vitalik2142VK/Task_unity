using UnityEngine;

public class MovementToTarget : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private Target _target;

    public Target Target 
    { 
        set 
        {
            _target = value; 
        } 
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }
}
