using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Transform _transform;

    [SerializeField] private Vector3 _offset = new Vector3(0, 3f, -5f);

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        var position = _target.position + _offset;
        position.x = 0;
        _transform.position = Vector3.Lerp(_transform.position, position, Time.deltaTime);
    }
}
