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


    void Start() => ScoreTopTxt.text = PlayerPrefs.GetInt("ScoreTop", ScoreTop).ToString();

    private void Update()
    {
        score1 = score / 2;
        if (score1 > ScoreTop)
        {
            PlayerPrefs.SetInt("ScoreTop", score1);
        }
        scoreDisplay.text = score1.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block") && DeathBool)
        {
            score++;
        }
    }
}
