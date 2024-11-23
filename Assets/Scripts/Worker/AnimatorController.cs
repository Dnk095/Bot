using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string IsWalk = "IsWalk";

    private int _isWalk = Animator.StringToHash(nameof(IsWalk));

    public void Walk()
    {
        _animator.SetBool(_isWalk, true);
    }

    public void StopWalk()
    {
        _animator.SetBool(_isWalk, false);
    }
}
