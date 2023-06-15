using UnityEngine;
using GooglePlayGames;

public class LeaderBoard : MonoBehaviour
{
    private void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("авторизация успешна");
            }
            else
            {
                Debug.LogError("авторизация не успешна");
            }
        });
    }

    public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }
    
}
