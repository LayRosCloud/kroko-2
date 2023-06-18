using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Toggle _autoJump;
    [SerializeField] private float _jumpForce;
    private bool _jump = true;
    private Rigidbody _rigidbody;
    private PlayerDeath _playerDeath;
    public bool IsStartedGame { get; set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerDeath = GetComponent<PlayerDeath>();
    }

    public float JumpForce
    {
        get { return _jumpForce; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            _jumpForce = value;
        }
    }
    private void Update()
    {
        if (CanJump() && _autoJump.isOn)
        {
            Jump();
        }
    }

    private bool CanJump()
    {
        return _jump && IsStartedGame && _playerDeath.IsDead == false;
    }

    public void Jump()
    {
        if (CanJump())
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z);
            _jump = false;
            PlayerEvents.Instance.JumpEvent.Invoke();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Block>() != null)
        {
            _jump = true;
        }
    }
}
