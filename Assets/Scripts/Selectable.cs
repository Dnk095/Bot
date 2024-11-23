using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Select()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Deselect()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }
}
