using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int IsWalk = Animator.StringToHash(nameof(IsWalk));

    public void Walk()
    {
        _animator.SetBool(IsWalk, true);
    }

    public void StopWalk()
    {
        _animator.SetBool(IsWalk, false);
    }
}
