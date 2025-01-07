using System;
using UnityEngine;

[RequireComponent(typeof(ObjectTransparency))]
public class Gold : PickingObject
{
    private ObjectTransparency _view;

    public bool IsFound { get; private set; } = false;

    public event Action<Gold> Destroing;

    private new void Awake()
    {
        base.Awake();
        _view = GetComponent<ObjectTransparency>();
    }

    public void ChangeState()
    {
        IsFound = true;
        _view.MakeItVisible();
    }

    public void Destroy()
    {
        Destroing?.Invoke(this);
    }
}
