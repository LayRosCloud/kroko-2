using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody Rb;
    private int _currentPos = 1;
    public float jumpForce;
    private bool facingRight = true;
    public int CoinScore;
    public Text ScoreCoin;
    public bool jump = true;
    public Toggle auto;
    private void Start()
    {
        QualitySettings.maxQueuedFrames = 0;
        Application.targetFrameRate = 60;

        Rb = GetComponent<Rigidbody>();
        CoinScore = PlayerPrefs.GetInt("Coin", CoinScore);
        ScoreCoin.text = CoinScore.ToString();
    }
    
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.z *= -1;
        transform.localScale = scaler;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            CoinScore++;
            PlayerPrefs.SetInt("Coin", CoinScore);
            ScoreCoin.text = CoinScore.ToString();
            
        }
        if (other.CompareTag("Kislota"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.CompareTag("Block"))
        {
            jump = true;
        }
    }
    public void LeftMove()
    {
        if (_currentPos - 1 < 0)
        {
            return;
        }
        
        if (facingRight)
        {
            Flip();
        }

        _currentPos--;
        transform.Translate(Vector3.back * moveSpeed);
    }
    public void RightMove()
    {
        if (_currentPos + 1 > 2)
        {
            return;
        }
        
        if (!facingRight)
        {
            Flip();
        }
        _currentPos++;
        transform.Translate(Vector3.forward * moveSpeed);
    }
    public void JumpButton()
    {
        if (!auto.isOn)
        {
            if (jump)
            {
                Rb.velocity = new Vector3(Rb.velocity.x, jumpForce, Rb.velocity.z);
                jump = false;
            }
        }
    }
}
