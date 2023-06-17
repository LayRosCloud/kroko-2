using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _scoreTopText;
    
    private int _score;
    private int _scoreTop;
    
    public bool IsDead { get; set; }

    void Start()
    {        
        _scoreTop = PlayerPrefs.GetInt("ScoreTop", 0);
        _scoreTopText.text = _scoreTop.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Block>() != null && IsDead == false)
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
            
            GoogleController.ReportToGoogle(_score);
            
            _scoreTopText.text = score.ToString();
        }
        
        _scoreText.text = score.ToString();
    }

    
}
