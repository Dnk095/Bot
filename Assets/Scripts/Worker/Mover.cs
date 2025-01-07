using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _coroutine;
    private Vector3 _target;

    public void Move(Vector3 target)
    {
        _target = target;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Transfer());
    }

    public void StopMove()
    {
        _target = transform.position;
    }

    private IEnumerator Transfer()
    {
        transform.LookAt(_target);

        float delay = Time.fixedDeltaTime;

        WaitForSeconds wait = new(delay);

        while (enabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.fixedDeltaTime);

            yield return wait;
        }

        _target = transform.position;
    }
}