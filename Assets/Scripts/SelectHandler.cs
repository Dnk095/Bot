using UnityEngine;

public class SelectHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _camera;

    private Selectable _selectable;

    private void OnEnable()
    {
        _inputReader.Selecting += Select;
        _inputReader.Deselecting += Deselect;
    }

    private void OnDisable()
    {
        _inputReader.Selecting -= Select;
        _inputReader.Deselecting -= Deselect;
    }

    private void Select()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent(out Selectable selectable) && _selectable != selectable)
            {
                _selectable = selectable;
                selectable.Select();
            }
        }
    }

    private void Deselect()
    {
        if (_selectable != null)
        {
            _selectable.Deselect();
            _selectable = null;
        }
    }
}
