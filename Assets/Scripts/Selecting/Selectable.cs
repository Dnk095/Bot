using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField] private SelectableInfo _info;

    public SelectableInfo GetSelctableInfo()
    {
        return _info;
    }   
}