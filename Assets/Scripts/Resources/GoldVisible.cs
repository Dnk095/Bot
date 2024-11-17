using UnityEngine;

internal class GoldVisible : MonoBehaviour
{
    [SerializeField] private Material _material;
    private Material _currentMaterial;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        ChangeColor(0);
    }

    public void ChangeVisible()
    {
        ChangeColor(1);
    }

    private void ChangeColor(float colorA)
    {
        Color color = _material.color;
        color.a = colorA;
        _material.color = color;
    }
}