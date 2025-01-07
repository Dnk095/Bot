using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
internal class ObjectTransparency : MonoBehaviour
{
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        ChangeVisible(0);
    }

    public void MakeItVisible()
    {
        int visible = 1;

        ChangeVisible(visible);
    }

    private void ChangeVisible(float colorA)
    {
        Color color = _material.color;
        color.a = colorA;
        _material.color = color;
    }
}