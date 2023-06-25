using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Main;
    public GameObject GamePanel;
    public GameObject Final;

    public  void Game()
    {
        Main.SetActive(false);
        GamePanel.SetActive(true);
    }

    public void Game2()
    {
        Main.SetActive(false);
        GamePanel.SetActive(false);
        Final.SetActive(true);
    }




}
