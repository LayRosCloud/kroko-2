using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerPosition), typeof(PlayerFlipper), typeof(PlayerParticle))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private PlayerFlipper _playerFlip;
    private PlayerPosition _playerPosition;

    private Direction _targetDirection;
    private Coroutine _coroutine;
    
    private void Awake()
    {
        _playerFlip = GetComponent<PlayerFlipper>();
        _playerPosition = GetComponent<PlayerPosition>();
    }

    private void Update()
    {
        sbyte target = (sbyte)_targetDirection;
        
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(MoveOnDirection(target));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightMove();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftMove();
        }
    }

    public void LeftMove()
    {
        if (_playerPosition.GetPosition() - 1 < 0)
        {
            return;
        }
        
        Flip(_playerFlip.CanLeftFlip());
        ChangeMove(Direction.Left);
    }
    
    public void RightMove()
    {
        if (_playerPosition.GetPosition() + 1 > 2)
        {
            return;
        }
        
        Flip(_playerFlip.CanRightFlip());
        ChangeMove(Direction.Right);
    }

    private void Flip(bool canFlip)
    {
        if (canFlip)
        {
            _playerFlip.Flip();
        }
    }
    
    private void ChangeMove(Direction direction)
    {
        sbyte numDirection = (sbyte)direction;
        if (numDirection > 0)
        {
            _playerPosition.MoveRight();
        }
        else
        {
            _playerPosition.MoveLeft();
        }
        PlayerEvents.Instance.MoveEvent.Invoke();
        _targetDirection = direction;
        _coroutine = null;
    }
    
    private IEnumerator MoveOnDirection(sbyte direction)
    {
        float unitMove = _moveSpeed / 5.0f; 
        
        sbyte center = _playerPosition.IsCenter();
        
        if (direction > 0)
        {
            for (float i = transform.position.x; i < direction * _moveSpeed * center; i += unitMove)
            {
                yield return new WaitForSeconds(0.001f);
                var position = transform.position;
                transform.position = new Vector3(i, position.y, position.z);
            }
        }
        else
        {
            for (float i = transform.position.x; i > direction * _moveSpeed * center; i -= unitMove)
            {
                yield return new WaitForSeconds(0.001f);
                var position = transform.position;
                transform.position = new Vector3(i, position.y, position.z);
            }
        }
    }

    private IEnumerator MoveTo(float to)
    {
        yield return new WaitForSeconds(0.001f);
        var position = transform.position;
        transform.position = new Vector3(to, position.y, position.z);
    }
}
