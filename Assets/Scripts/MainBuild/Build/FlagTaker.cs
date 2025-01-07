using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagTaker : MonoBehaviour
{
    [SerializeField] private FlagButton _flagButton;
    [SerializeField] private Camera _camera;  

    private void OnEnable()
    {
        _flagButton.Used += OnUsed;
    }

    private void OnDisable()
    {
        _flagButton.Used -= OnUsed;
    }

    private void OnUsed()
    {
       
    }
}
