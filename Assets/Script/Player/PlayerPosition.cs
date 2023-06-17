using System;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private sbyte _currentPosition = 1;
    
    private const sbyte MAXIMUM = 2;
    private const sbyte MINIMUM = 0;
    
    private const sbyte STEP = 1;
    
    private Direction _targetDirection;

    public void MoveLeft()
    {
        if (CanLeftMove() == false)
        {
            throw new ArgumentException("Вы вышли за пределы!");
        }

        _currentPosition -= STEP;
    }
    
    public void MoveRight()
    {
        if (CanRightMove() == false)
        {
            throw new ArgumentException("Вы вышли за пределы!");
        }

        _currentPosition += STEP;
    }
    public bool CanRightMove()
    {
        return _currentPosition + STEP <= MAXIMUM;
    }
    
    public bool CanLeftMove()
    {
        return _currentPosition - STEP >= MINIMUM;
    }
    
    public sbyte GetPosition()
    {
        return _currentPosition;
    }
    

    public sbyte IsCenter()
    {
        return (sbyte)(_currentPosition == 1 ? 0 : 1);
    }
}