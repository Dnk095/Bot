using TMPro;
using UnityEngine;

public class SelectDrawer : MonoBehaviour
{
    [SerializeField] private SelectHandler _selectHandler;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _golds;

    private SelectableInfo _selectedInfo;

    private void OnEnable()
    {
        _selectHandler.Selecting += OnSelecting;
        _selectHandler.DeSelecting += OnDeSelecting;
    }

    private void OnDisable()
    {
        _selectHandler.Selecting -= OnSelecting;
        _selectHandler.DeSelecting -= OnDeSelecting;
    }

    private void OnSelecting(SelectableInfo selectableInfo)
    {
        _canvasGroup.alpha = 1.0f;
        _selectedInfo = selectableInfo;
        _selectedInfo.ChangedGold += OnChangeGolds;
        _text.text = _selectedInfo.Name;
        _golds.text = _selectedInfo.QuantityGolds.ToString();
    }

    private void OnDeSelecting()
    {
        _selectedInfo.ChangedGold -= OnChangeGolds;
        _canvasGroup.alpha = 0;
    }

    private void OnChangeGolds(int quantity)
    {
        _golds.text = quantity.ToString();
    }
}
