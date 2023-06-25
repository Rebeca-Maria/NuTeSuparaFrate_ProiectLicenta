using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPleyerPiesa : PlayerPiesa
{
    ZarR yellowHomeZarR;
    void Start()
    {
        yellowHomeZarR = GetComponentInParent<YellowHome>().zarR;
    }

    public void OnMouseDown()
    {
        if (GameManager.gm.zarR != null)
        {


            if (!isReady)
            {
                if (GameManager.gm.zarR == yellowHomeZarR && GameManager.gm.numberOfSteptToMove == 6)
                {

                    GameManager.gm.yellowOutPlayers += 1;
                    MakePlayerReadytoMove(pathParent.YellowPathPoints);
                    GameManager.gm.numberOfSteptToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.zarR == yellowHomeZarR && isReady && GameManager.gm.CanPlayerMove)
            {
                GameManager.gm.CanPlayerMove = false;
                MoveSteps(pathParent.YellowPathPoints);
            }
        }
    }
    

}
