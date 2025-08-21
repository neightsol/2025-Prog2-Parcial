using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTrcaker : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform _targetTransform;

    private Vector3 _offSet = new();

    private void Start()
    {
        _offSet = transform.position - _targetTransform.position;
    }

    private void LateUpdate()
    {
        transform.position = _targetTransform.position + _offSet;
    }
}
