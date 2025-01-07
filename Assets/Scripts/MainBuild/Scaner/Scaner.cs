using System;
using System.Collections;
using UnityEngine;

public class Scaner : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _scanTime = 1f;
    [SerializeField] private GoldList _golds;
    [SerializeField] private ScanButton _scanButton;

    private Coroutine _coroutine;
    private Vector3 _scanPosition;
    private bool _isScaning = false;

    public event Action<float> ChangeTime;
    public event Action Scaning;

    private void OnEnable()
    {
        _scanButton.Used += OnUsed;
    }

    private void OnDisable()
    {
        _scanButton.Used -= OnUsed;
    }

    public void Scan(Vector3 position )
    {
        _scanPosition = position;

        if (_coroutine != null && _isScaning == false )
            StopCoroutine(_coroutine);

        if (_isScaning == false )
            _coroutine = StartCoroutine(StartScan());
    }

    private void OnUsed()
    {
        Scaning?.Invoke();
    }

    private IEnumerator StartScan()
    {
        _isScaning = true;

        float delay = Time.fixedDeltaTime;
        float currrentTime = 0;

        WaitForSeconds wait = new(delay);

        while (currrentTime < _scanTime)
        {
            ChangeTime?.Invoke(currrentTime / _scanTime);
            currrentTime += delay;

            yield return wait;
        }

        _isScaning = false;

        Collider[] hits = Physics.OverlapSphere(_scanPosition, _radius);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out Gold gold) && gold.IsFound == false)
            {
                gold.ChangeState();
                _golds.AddGold(gold);
            }
        }
    }
}
