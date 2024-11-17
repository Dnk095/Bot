using UnityEngine;

[RequireComponent(typeof(PickingObject))]
public class Gold : MonoBehaviour
{
    private PickingObject _pickingObject;
    private GoldVisible _view;

    private bool _isFound = false;

    public bool IsFound => _isFound;

    private void Awake()
    {
        _pickingObject = GetComponent<PickingObject>();
        _view = GetComponent<GoldVisible>();
    }

    public void ChangeState()
    {
        _isFound = true;
        _view.ChangeVisible();
    }

    public void PickUp(Transform parent, float distance)
    {
        _pickingObject.PickUp(parent, distance);
    }
}
