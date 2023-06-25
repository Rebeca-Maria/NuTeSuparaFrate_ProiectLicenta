using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerPiesa : PlayerPiesa
{
    ZarR greenHomeZarR;
    void Start()
    {
        greenHomeZarR = GetComponentInParent<GreenHome>().zarR;
    }

    public void OnMouseDown()
    {
        if (GameManager.gm.zarR != null)
        {


            if (!isReady)
            {
                if (GameManager.gm.zarR == greenHomeZarR && GameManager.gm.numberOfSteptToMove == 6)
                {

                    GameManager.gm.greenOutPlayers += 1;
                    MakePlayerReadytoMove(pathParent.GreenPathPoints);
                    GameManager.gm.numberOfSteptToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.zarR == greenHomeZarR && isReady)
            {

                MoveSteps(pathParent.GreenPathPoints);
            }
        }
    }
}
