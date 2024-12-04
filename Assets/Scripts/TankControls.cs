using UnityEngine;
using UnityEngine.InputSystem;

public class TankControls : MonoBehaviour
{
    [SerializeField] private float _linearSpeed = 1f;
    [SerializeField] private float _rollSpeed = 2f;
    
    private float _moveInput = 0f;
    private float _spinInput = 0f;
    private bool _isalive=true;
    
    private Rigidbody _rigidbody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogWarning("No rigidbody attached");
        }
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.AddForce(transform.forward * (_moveInput*_linearSpeed)); 
        _rigidbody.AddRelativeTorque(0, _spinInput * _rollSpeed, 1);
    }

    void OnMovement(InputValue value)
    {
        _moveInput = value.Get<float>();
        if (_moveInput > 0.6f)
        {
            _moveInput = 0.6f;
        }
        else if (_moveInput < -0.6f)
        {
            _moveInput = -0.6f;
        }
    }
    
    void OnSpinning(InputValue value)
    {
        _spinInput = value.Get<float>();
        if (_spinInput > 0.5f)
        {
            _spinInput = 0.5f;
        }
        else if (_spinInput < -0.5f)
        {
            _spinInput = -0.6f;
        }
    }
    public void PlayerDeath()
    {
        _isalive = false;
        if (_isalive == false)
        {
            Destroy(gameObject,0);
        }
    }
}

