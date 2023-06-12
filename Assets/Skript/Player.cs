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
    [SerializeField] private GameObject _particleStep;
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private AudioSource _moneySound;
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private GameObject _deathCanvas;

    private AudioSource _audio;
    private int _currentPos = 1;

    private bool _facingRight = true;
    private int _coinScore;

    public Rigidbody Rigidbody { get; private set; }

    private bool _jump = true;

    private Direction _targetDirection;
    private Coroutine _coroutine;
    public int CurrentPosition => _currentPos;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        QualitySettings.maxQueuedFrames = 0;
        Application.targetFrameRate = 60;

        Rigidbody = GetComponent<Rigidbody>();

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
            _moneySound.Play();
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin", 0) + 1);
            ViewMoney();
        }
        if (other.CompareTag("Kislota"))
        {
            _deathSound.Play();
            _deathCanvas.SetActive(true);
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

        GameObject gm = Instantiate(_particleStep);
        gm.transform.position = transform.position;
        Destroy(gm, 0.2f);
        _currentPos += numDirection;
        
        _targetDirection = direction;
        _audio.Play();
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
            _jumpSound.Play();
            Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, _jumpForce, Rigidbody.velocity.z);
            _jump = false;
        }
    }
}
