using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _scoreTopText;
    [SerializeField] private PlayerDeath _playerDeath;
    
    private int _score;
    private int _scoreTop;
    
    void Start()
    {        
        _scoreTop = PlayerPrefs.GetInt("ScoreTop", 0);
        _scoreTopText.text = _scoreTop.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Block>() != null && _playerDeath.IsDead == false)
        {
            _score++;
            
            UpdateUI(_score);
        }

        if (other.gameObject.GetComponent<Block>() != null)
        {
            Destroy(other.gameObject);
        }
    }

    private void UpdateUI(int score)
    {
        if (score > _scoreTop)
        {
            PlayerPrefs.SetInt("ScoreTop", score);
            
            
            _scoreTopText.text = score.ToString();
        }
        
        _scoreText.text = score.ToString();
    }

    
}
