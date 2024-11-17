using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        if (_inputReader.VerticalDirection != 0)
            Move();

        if (_inputReader.HorizontalDirection != 0)
            Rotate();
    }

    private void Move()
    {
        Vector3 direction = new(0f, 0f, _inputReader.VerticalDirection);

        transform.Translate(_speed * direction * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(_inputReader.HorizontalDirection * _rotateSpeed * Time.deltaTime * Vector3.up);
    }
}
