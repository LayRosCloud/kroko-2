using UnityEngine;
using UnityEngine.UI;

public class Scope : MonoBehaviour
{
    private int score;
    private int score1;
    public Text scoreDisplay;
    private int ScoreTop;
    public Text ScoreTopTxt;
    public bool DeathBool = true;


    void Start()
    {
        ScoreTopTxt.text = PlayerPrefs.GetInt("ScoreTop", ScoreTop).ToString();
        ScoreTop = PlayerPrefs.GetInt("ScoreTop", 0);
    } 

    private void Update()
    {
        score1 = score / 2;
        if (score1 > ScoreTop)
        {
            PlayerPrefs.SetInt("ScoreTop", score1);
            Social.ReportScore(score1, GPS.leaderboard_willy_jump, success =>
            {
                if (success)
                {
                    Debug.Log("успешная отправка");
                }
                else
                {
                    Debug.Log("Отправка не успешна");
                }
            });
        }
        scoreDisplay.text = score1.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block") && DeathBool)
        {
            Destroy(other.gameObject);
            score++;
        }
    }
}
