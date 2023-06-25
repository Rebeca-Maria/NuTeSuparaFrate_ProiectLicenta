using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerPiesa : PlayerPiesa
{
    ZarR redHomeZarR;
    void Start()
    {
        redHomeZarR = GetComponentInParent<RedHome>().zarR;
    }

    public void OnMouseDown()
    {
        if (GameManager.gm.zarR != null)
        {


            if (!isReady)
            {
                if (GameManager.gm.zarR == redHomeZarR && GameManager.gm.numberOfSteptToMove == 6)
                {

                    GameManager.gm.redOutPlayers += 1;
                    MakePlayerReadytoMove(pathParent.RedPathPoints);
                    GameManager.gm.numberOfSteptToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.zarR == redHomeZarR && isReady)
            {

                MoveSteps(pathParent.RedPathPoints);
            }
        }
    }
}
