using Snake.Global;
using UnityEngine;

public class Head : MonoBehaviour
{
    private Transform _transform;

    private float _speed;
    private float _positionX;

    private void Start()
    {
        _transform = transform;
        _speed = GlobalParams.SnakeSpeed;
    }

    private void Update()
    {
        Vector3 position = _transform.position;
        position.x = position.x > _positionX ?
            Mathf.Max(_positionX, position.x - _speed * Time.deltaTime) :
            Mathf.Min(_positionX, position.x + _speed * Time.deltaTime);
        position.z += _speed * Time.deltaTime;
        _transform.position = position;
    }

    public void Move(float x)
    {
        _positionX = x;
    }
}
