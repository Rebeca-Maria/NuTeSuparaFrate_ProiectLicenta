using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerPiesa : PlayerPiesa
{
    ZarR blueHomeZarR;
    void Start()
    {
        blueHomeZarR = GetComponentInParent<BlueHome>().zarR;
    }

    public void OnMouseDown()
    {
        if (GameManager.gm.zarR != null)
        {


            if (!isReady)
            {
                if (GameManager.gm.zarR == blueHomeZarR && GameManager.gm.numberOfSteptToMove == 6)
                {

                    GameManager.gm.blueOutPlayers += 1;
                    MakePlayerReadytoMove(pathParent.BluePathPoints);
                    GameManager.gm.numberOfSteptToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.zarR == blueHomeZarR && isReady)
            {

                MoveSteps(pathParent.BluePathPoints);
            }
        }
    }
}
