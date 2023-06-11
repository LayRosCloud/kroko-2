using UnityEngine;
using UnityEngine.UI;

public class Scope : MonoBehaviour
{
    public int score;
    public int score1;
    public Text scoreDisplay;
    public int ScoreTop;
    public Text ScoreTopTxt;


    private void Start()
    {
        ScoreTop = PlayerPrefs.GetInt("ScoreTop", ScoreTop);
    }

    void Update()
    {
        score1 = score / 2;
        if (score1 > ScoreTop)
        {
            ScoreTop = score1;
        }
        PlayerPrefs.SetInt("ScoreTop", ScoreTop);
        scoreDisplay.text = score1.ToString();
        ScoreTopTxt.text = ScoreTop.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            score++;
        }
    }
}
