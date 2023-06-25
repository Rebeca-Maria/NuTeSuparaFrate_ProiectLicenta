using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPiesa : MonoBehaviour
{
    public bool moveNow;
    public bool isReady;
    public int numberOfStepsToMove;
    public int numberOfStepsAlreadyMove;
    public PathObjectParent pathParent;
    Coroutine MovePlayerPiesa;

    public PathPoint previosPathPoint;
    public PathPoint curentPathPoint;

    private void Awake()
    {
        pathParent=FindObjectOfType<PathObjectParent>();
    }

    public void MoveSteps(PathPoint[] pathPointsToMoveon_)
    {
       MovePlayerPiesa= StartCoroutine(MoveSteps_Enum(pathPointsToMoveon_));
    }

    public void MakePlayerReadytoMove(PathPoint[] pathPointsToMoveon_)
    {
        isReady= true;
        transform.position = pathPointsToMoveon_[0].transform.position;
        numberOfStepsAlreadyMove = 1;

        previosPathPoint= pathPointsToMoveon_[0];
        curentPathPoint= pathPointsToMoveon_[0];
        curentPathPoint.AddPlayerPiesa(this);
        GameManager.gm.AddPathPoint(curentPathPoint);

        GameManager.gm.CanZarRoll= true;
        GameManager.gm.selfZar = true;
        GameManager.gm.transferZar = false;
    }
    IEnumerator MoveSteps_Enum(PathPoint[] pathPointsToMoveon_)
    {
        GameManager.gm.transferZar = false;
        yield return new WaitForSeconds(0.25f);
        numberOfStepsToMove = GameManager.gm.numberOfSteptToMove;
        for (int i = numberOfStepsAlreadyMove; i < (numberOfStepsAlreadyMove + numberOfStepsToMove); i++)
        {
            curentPathPoint.RescaleandReposition();
            if (isPathPointAvalabil(numberOfStepsToMove, numberOfStepsAlreadyMove, pathPointsToMoveon_))
            {
                transform.position = pathPointsToMoveon_[i].transform.position;
                yield return new WaitForSeconds(0.35f);
            }
        }
        if (isPathPointAvalabil(numberOfStepsToMove, numberOfStepsAlreadyMove, pathPointsToMoveon_))
        {
           
            numberOfStepsAlreadyMove += numberOfStepsToMove;
            

            GameManager.gm.RemovePathPoint(previosPathPoint);
            previosPathPoint.RemovePlayerPiesa(this);
            curentPathPoint = pathPointsToMoveon_[numberOfStepsAlreadyMove - 1];


            if (curentPathPoint.AddPlayerPiesa(this))
            {
                if(numberOfStepsAlreadyMove==49)
                {
                    GameManager.gm.selfZar = true;
                }
                else
                {

                    if (GameManager.gm.numberOfSteptToMove != 6)
                    {

                        GameManager.gm.transferZar = true;
                    }
                    else
                    {
                        GameManager.gm.selfZar = true;
                    }
                }

            }
            else
            {
                GameManager.gm.selfZar = true;
            }

            GameManager.gm.AddPathPoint(curentPathPoint);
            previosPathPoint = curentPathPoint;

            GameManager.gm.numberOfSteptToMove = 0;

           
        }
        GameManager.gm.CanPlayerMove = true;
        GameManager.gm.RollZarManager();

        if (MovePlayerPiesa != null)
        {
            StopCoroutine("MoveSteps_Enum");
        }
    }

    bool isPathPointAvalabil(int numOfStepToMove_,int numOfStepAlreadyMove, PathPoint[] pathPointtoMove_)
    {
        if(numOfStepToMove_==0)
        {
            return false;
        }
        int leftNumOfPath = pathPointtoMove_.Length - numOfStepAlreadyMove;
        if (leftNumOfPath >= numOfStepToMove_)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
