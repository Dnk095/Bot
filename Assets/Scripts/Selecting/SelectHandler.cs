using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _camera;
    [SerializeField] private Scaner _scaner;

    private Selectable _selectable;
    private bool _isScaning = false;

    public event Action<SelectableInfo> Selecting;
    public event Action DeSelecting;

    private void OnEnable()
    {
        _inputReader.Selecting += Select;
        _inputReader.Deselecting += Deselect;
        _scaner.Scaning += OnScaning;
    }

    private void OnDisable()
    {
        _inputReader.Selecting -= Select;
        _inputReader.Deselecting -= Deselect;
        _scaner.Scaning -= OnScaning;
    }

    private void Select()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent(out Selectable selectable) && _selectable != selectable)
            {
                _selectable = selectable;
                Selecting?.Invoke(_selectable.GetSelctableInfo());
            }
            else if (_selectable != null && _selectable.gameObject.TryGetComponent(out MainBuild mainBuild) && !EventSystem.current.IsPointerOverGameObject() && _isScaning == false)
            {
                mainBuild.GetFlagPosition(hit.point);
            }
            else if (_isScaning == true)
            {
                _scaner.Scan(hit.point);
                _isScaning = false;
            }
        }
    }

    private void Deselect()
    {
        if (_selectable != null)
        {
            DeSelecting?.Invoke();
            _selectable = null;
        }
    }

    private void OnScaning()
    {
        _isScaning = true;
    }

}
