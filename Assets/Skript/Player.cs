using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody Rb;
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
    }

    private void Update()
    {
        PlayerPrefs.SetInt("Coin", CoinScore);
        ScoreCoin.text = CoinScore.ToString();
        if (!facingRight && Rb.velocity.x > 0)
        {
            Flip();
        }
        else if (facingRight && Rb.velocity.x < 0)
        {
            Flip();
        }
        if (auto.isOn)
        {
            if (jump)
            {
                Rb.velocity = new Vector3(Rb.velocity.x, jumpForce, Rb.velocity.z);
                jump = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && jump)
            {
                Rb.velocity = new Vector3(Rb.velocity.x, jumpForce, Rb.velocity.z);
                jump = false;
            }
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.z *= -1;
        transform.localScale = Scaler;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            CoinScore++;
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
        transform.Translate(Vector3.back * moveSpeed);
    }
    public void RightMove()
    {
        transform.Translate(Vector3.forward* moveSpeed);
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
