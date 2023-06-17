
using UnityEngine;

public class GoogleController
{
    public static void ReportToGoogle(int score)
    {
        Social.ReportScore(score, GPS.leaderboard_willy_jump, success =>
        {
            Debug.Log(success ? "Успешная отправка на сервер" : "Провальная отправка");
        });
    }
}
