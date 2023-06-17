
using UnityEngine;

public class PlayerFlipper : MonoBehaviour
{
    private bool _facingRight = true;
    
    public void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scaler = transform.localScale;
        scaler.z *= -1;
        transform.localScale = scaler;
    }

    public bool CanLeftFlip()
    {
        return _facingRight == true;
    }
    
    public bool CanRightFlip()
    {
        return _facingRight == false;
    }
}
