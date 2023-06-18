using UnityEngine;
using UnityEngine.Serialization;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject _canvasMenu;
    [SerializeField] private GameObject _canvasGame;
    [SerializeField] private GameObject _canvasStart;
    [Space]
    [SerializeField] private Learning _learning;
    [Space]
    [SerializeField] private Spawner _spawner;
    [SerializeField] private StartBlock _startBlock;
    [SerializeField] private WaterUp _waterUp;
    [SerializeField] private PlayerJump _playerJump;
    
    public void Button()
    {
        _canvasMenu.SetActive(false);
        _canvasGame.SetActive(true);
        StartCoroutine(_learning.StartLearnCoroutine(() =>
            {
                LearnCompleted();
            }
        ));

    }

    public void LearnCompleted()
    {
        _spawner.IsStartGame = true;
        _startBlock.Raz = true;
        _waterUp.IsStartGame = true;
        _playerJump.IsStartedGame = true;
        
        _canvasStart.SetActive(true);
    }
}
