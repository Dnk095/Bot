using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickingObject : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void PickUp(Transform parent, float holdDistance)
    {
        transform.SetParent(parent);
        transform.localPosition = new Vector3(0f, 0f, holdDistance);

        _rigidbody.isKinematic = true;
    }
}
