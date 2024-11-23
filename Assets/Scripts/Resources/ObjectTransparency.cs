using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
internal class ObjectTransparency : MonoBehaviour
{
    private Material _material;
    private Material _currentMaterial;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        ChangeVisible(0);
    }

    public void ChangeVisible()
    {
        ChangeVisible(1);
    }

    private void ChangeVisible(float colorA)
    {
        Color color = _material.color;
        color.a = colorA;
        _material.color = color;
    }
}