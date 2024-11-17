using System;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(AnimatorController))]
public class Worker : MonoBehaviour
{
    [SerializeField] private float _holdDistance;
    [SerializeField] private Transform _hand;

    private AnimatorController _controller;
    private Distributor _distributor;
    private Mover _mover;
    private Gold _gold;

    private bool _haveGold = false;

    public event Action<Worker> ReturnedToBase;

    private void Awake()
    {
        _controller = GetComponent<AnimatorController>();
        _mover = GetComponent<Mover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Gold gold) && gold == _gold)
        {
            _controller.StopWalk();
            gold.PickUp(_hand, _holdDistance);
            _haveGold = true;
            ReturnToBase();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out MainBuild _) && _haveGold == true)
        {
            _controller.StopWalk();
            ReturnedToBase?.Invoke(this);
            _mover.Move(transform.position);
            _gold.transform.SetParent(null);
            _haveGold = false;
            Destroy(_gold.gameObject);
        }
    }

    public void InitCreated(Distributor distributor)
    {
        _distributor = distributor;
    }

    public void Init(Gold gold)
    {
        _controller.Walk();
        _gold = gold;
        _mover.Move(gold.transform.position);
    }

    private void ReturnToBase()
    {
        _controller.Walk();
        _mover.Move(_distributor.transform.position);
    }
}