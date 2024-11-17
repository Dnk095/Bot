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

    private bool _isScaning = false;

    public event Action<float> ChangeTime;

    private void OnEnable()
    {
        _scanButton.Used += Scan;
    }

    private void OnDisable()
    {
        _scanButton.Used -= Scan;
    }

    private void Scan()
    {
        if (_coroutine != null && _isScaning == false)
            StopCoroutine(_coroutine);

        if (_isScaning == false)
            _coroutine = StartCoroutine(StartScan());
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

        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

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
