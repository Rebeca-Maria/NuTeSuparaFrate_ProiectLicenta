using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public ZarR zarR;
    public int numberOfSteptToMove;
    public bool CanPlayerMove = true;

    List<PathPoint> playerOnPathPointList = new List<PathPoint>();

    public bool CanZarRoll = true;
    public bool transferZar = false;
    public bool selfZar=false;

    public int yellowOutPlayers;
    public int redOutPlayers;
    public int greenOutPlayers;
    public int blueOutPlayers;

    public int yellowCompletPlayers;
    public int redCompletPlayers;
    public int greenCompletPlayers;
    public int blueCompletPlayers;

    public ZarR[] manageZarR;

    public PlayerPiesa[] YellowPlayerPiesa;
    public PlayerPiesa[] RedPlayerPiesa;
    public PlayerPiesa[] BluePlayerPiesa;
    public PlayerPiesa[] GreenPlayerPiesa;

    private void Awake()
    {
        gm = this;
    }

    public void AddPathPoint(PathPoint pathPoint)
    {
        playerOnPathPointList.Add(pathPoint);
    }
    public void RemovePathPoint(PathPoint pathPoint)
    {
        if(playerOnPathPointList.Contains(pathPoint))
        {
            playerOnPathPointList.Remove(pathPoint);
        }
        else
        {
            Debug.Log("path is not found to remove");
        }
    }

    public void RollZarManager()
    {
        int nextZar;
        if (GameManager.gm.transferZar)
        {
            for(int i = 0; i < 4; i++)
            {
                if (i == 3) { nextZar = 0; } else { nextZar = i + 1; }
                
                if(GameManager.gm.zarR== GameManager.gm.manageZarR[i])
                {
                    GameManager.gm.manageZarR[i].gameObject.SetActive(false);
                    GameManager.gm.manageZarR[nextZar].gameObject.SetActive(true);
                }
            }
            GameManager.gm.CanZarRoll = true;
        }
        else
        {
            if(GameManager.gm.selfZar) {
                GameManager.gm.selfZar = false;
                GameManager.gm.CanZarRoll = true;
            }
        }
    }
}
