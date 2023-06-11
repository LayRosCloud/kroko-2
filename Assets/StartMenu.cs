using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartMenu : MonoBehaviour
{
    public GameObject CanvasMenu;
    public GameObject CanvasGame;
    public GameObject CanvasStart;
    public GameObject CanvasOption;

    public void Button()
    {
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().IsStartGame = true;
        GameObject.FindGameObjectWithTag("StartBlock").GetComponent<StartBlock>().Raz = true;
        CanvasMenu.SetActive(false);
        CanvasGame.SetActive(true);
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
