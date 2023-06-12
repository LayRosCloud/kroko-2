using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Toggle = UnityEngine.UI.Toggle;


public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Toggle _autoJump;
    [SerializeField] private Text _scoreCoin;
    [SerializeField] private float _jumpForce;

    private int _currentPos = 1;

    private bool _facingRight = true;
    private int _coinScore;

    private Rigidbody _rigidbody;

    private bool _jump = true;

    private Direction _targetDirection;
    private Coroutine _coroutine;

    private void Start()
    {
        QualitySettings.maxQueuedFrames = 0;
        Application.targetFrameRate = 60;

        _rigidbody = GetComponent<Rigidbody>();

        _coinScore = PlayerPrefs.GetInt("Coin", _coinScore);
        _scoreCoin.text = _coinScore.ToString();
    }

    private void Update()
    {
        sbyte target = (sbyte)_targetDirection;

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(MoveTo(target));
        }
    }

    private IEnumerator MoveTo(sbyte direction)
    {
        float unitMove = _moveSpeed / 5;
        
        int pos = _currentPos == 1 ? 0 : 1;
        
        if (direction > 0)
        {
            for (float i = transform.position.x; i < direction * _moveSpeed * pos; i += unitMove)
            {
                yield return new WaitForSeconds(0.001f);
                var position = transform.position;
                transform.position = new Vector3(i, position.y, position.z);
            }
        }
        else
        {
            for (float i = transform.position.x; i > direction * _moveSpeed * pos; i -= unitMove)
            {
                yield return new WaitForSeconds(0.001f);
                var position = transform.position;
                transform.position = new Vector3(i, position.y, position.z);
            }
        }
        
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scaler = transform.localScale;
        scaler.z *= -1;
        transform.localScale = scaler;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin", 0) + 1);
            ViewMoney();
        }
        if (other.CompareTag("Kislota"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.CompareTag("Block"))
        {
            _jump = true;
        }
    }

    public void ViewMoney()
    {
        _scoreCoin.text = PlayerPrefs.GetInt("Coin", 0).ToString();
    }
    
    public void LeftMove()
    {
        if ((sbyte)_currentPos - 1 < 0)
        {
            return;
        }
        if (_facingRight)
        {
            Flip();
        }
        ChangeMove(Direction.Left);
    }
    
    public void RightMove()
    {
        if (_currentPos + 1 > 2)
        {
            return;
        }
        if (!_facingRight)
        {
            Flip();
        }
        ChangeMove(Direction.Right);
    }

    private void ChangeMove(Direction direction)
    {
        sbyte numDirection = (sbyte)direction;
        
        _currentPos += numDirection;
        
        _targetDirection = direction;
        
        _coroutine = null;
    }
    
    public void JumpButton()
    {
        if (_autoJump.isOn)
        {
            return;
        }
        if (_jump)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z);
            _jump = false;
        }
    }
}
