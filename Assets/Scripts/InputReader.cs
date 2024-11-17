using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private int _mouseButtonSelect = 0;
    private int _mouseButtonDeselect = 1;

    public float VerticalDirection { get; private set; }
    public float HorizontalDirection { get; private set; }

    public event Action Selecting;
    public event Action Deselecting;

    private void Update()
    {
        HorizontalDirection = Input.GetAxis(Horizontal);
        VerticalDirection = Input.GetAxis(Vertical);

        if (Input.GetMouseButtonDown(_mouseButtonSelect))
            Selecting?.Invoke();
        else if (Input.GetMouseButtonDown(_mouseButtonDeselect))
            Deselecting?.Invoke();
    }
}
