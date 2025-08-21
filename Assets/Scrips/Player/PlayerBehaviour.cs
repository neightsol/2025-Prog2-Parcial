using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] private float _moveSpeed = 3.5f;
    [SerializeField] private float _rotSpeed = 50.0f;
    [SerializeField] private float _jumpForce = 5;

    private Rigidbody _rb;
    private Vector2 _moveInputs = new();
    private Vector3 _moveDir = new();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        //bloquear rotaciones no utilizadas por rigibody
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        _moveInputs.x = Input.GetAxis("Horizontal");
        _moveInputs.y = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        if (_moveInputs.sqrMagnitude != 0.0f)
        {
            Movement(_moveInputs);
        }
    }
    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }
    private void Movement(Vector2 Inputs)
    {

        _moveDir = (transform.right * Inputs.x + transform.forward * Inputs.y).normalized;
        _rb.MovePosition(transform.position + _moveDir * _moveSpeed * Time.fixedDeltaTime);
        Debug.Log(_moveDir);
    }
}
