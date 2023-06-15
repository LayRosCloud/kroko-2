using UnityEngine;


public class StartMenu : MonoBehaviour
{
    [SerializeField]private GameObject CanvasMenu;
    [SerializeField]private GameObject CanvasGame;
    [SerializeField]private GameObject CanvasStart;
    [SerializeField]private GameObject CanvasOption;
    [SerializeField] private Learning _learning; 
    
    public void Button()
    {
        CanvasMenu.SetActive(false);
        CanvasGame.SetActive(true);
        StartCoroutine(_learning.StartLearnCoroutine(() =>
            {
                LearnCompleted();
            }
        ));

    }

    public void LearnCompleted()
    {
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().IsStartGame = true;
        GameObject.FindGameObjectWithTag("StartBlock").GetComponent<StartBlock>().Raz = true;
        FindObjectOfType<WaterUp>().IsStartGame = true;
        FindObjectOfType<Player>().IsStartedGame = true;
        
        CanvasStart.SetActive(true);
    }

    public void ButtonOption()
    {
        CanvasOption.SetActive(true);
    }
    public void ButtonOptionOff()
    {
        CanvasOption.SetActive(false);
    }
}
