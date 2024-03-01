using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private Vector3 _direction;

    public Vector3 Direction 
    { 
        set 
        { 
            _direction = value; 
        } 
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);
    }
}
