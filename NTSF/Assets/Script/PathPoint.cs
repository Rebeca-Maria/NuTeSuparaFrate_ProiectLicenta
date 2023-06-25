using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    PathPoint[] pathPointToMoveOn_;
    public PathObjectParent pathObjectParent;
    public List<PlayerPiesa> PlayerPiesaList = new List<PlayerPiesa>();
    public GameObject Final_;
    public GameObject Canvas;

    private void Start()
    {
        pathObjectParent = GetComponentInParent<PathObjectParent>();
    }

    public bool AddPlayerPiesa(PlayerPiesa playerPiesa_)
    {

        if (this.name!="PathPoint" && this.name != "PathPoint (11)" && this.name != "PathPoint (22)" &&  this.name != "PathPoint (33)" && this.name != "CentruPath") 
        {
            if (this.name == "CentruPath") { Complet(playerPiesa_); }
            if (PlayerPiesaList.Count == 1)
            {
                string preePlayerPiesaNume = PlayerPiesaList[0].name;
                string curentPlayerPiesaNume = playerPiesa_.name;
                curentPlayerPiesaNume = curentPlayerPiesaNume.Substring(0, curentPlayerPiesaNume.Length - 4);

                if (!preePlayerPiesaNume.Contains(curentPlayerPiesaNume))
                {
                    PlayerPiesaList[0].isReady = false;
                    revertOnStart(PlayerPiesaList[0]);


                    PlayerPiesaList[0].numberOfStepsAlreadyMove = 0;
                    RemovePlayerPiesa(PlayerPiesaList[0]);
                    PlayerPiesaList.Add(playerPiesa_);

                    return false;
                }
            }
        }
        addPlayer(playerPiesa_);
        return true;
    }

    void revertOnStart(PlayerPiesa playerPiesa_)
    {
       
        PlayerPiesaList[0].transform.position = pathObjectParent.BazaPoints[BazaPointPosition(playerPiesa_.name)].transform.position;
    }

    int BazaPointPosition(string name)
    {
        if (name.Contains("Yellow")) { GameManager.gm.yellowOutPlayers -= 1; pathPointToMoveOn_ = pathObjectParent.YellowPathPoints; }
        else if (name.Contains("Red")) { GameManager.gm.redOutPlayers -= 1; pathPointToMoveOn_ = pathObjectParent.RedPathPoints; }
        else if (name.Contains("Blue")) { GameManager.gm.blueOutPlayers -= 1; pathPointToMoveOn_ = pathObjectParent.BluePathPoints; }
        else if (name.Contains("Green")) { GameManager.gm.greenOutPlayers -= 1; pathPointToMoveOn_ = pathObjectParent.GreenPathPoints; }


        for (int i=0;i<pathObjectParent.BazaPoints.Length;i++)
        {
            if (pathObjectParent.BazaPoints[i].name==name)
            {
                return i;
            }
        }
        return -1;
    }

    void addPlayer(PlayerPiesa playerPiesa_)
    {
        PlayerPiesaList.Add(playerPiesa_);
        RescaleandReposition();
    }
    public void RemovePlayerPiesa(PlayerPiesa playerPiesa_)
    {
        if (PlayerPiesaList.Contains(playerPiesa_))
        {
            PlayerPiesaList.Remove(playerPiesa_);
            RescaleandReposition();
        }
    }

    private void Complet(PlayerPiesa playerPiesa)
    {
        if (name.Contains("Yellow")) 
        { 
            GameManager.gm.yellowCompletPlayers += 1; GameManager.gm.yellowOutPlayers -= 1;
            if (GameManager.gm.yellowCompletPlayers == 4) 
            { 
                Canvas.SetActive(false); Final_.SetActive(true);
            } 
        }
        else if (name.Contains("Red"))
        {
            GameManager.gm.redCompletPlayers += 1; GameManager.gm.redOutPlayers -= 1;
            if (GameManager.gm.redCompletPlayers == 4) { ShowCelebration();
            }
        }
        else if (name.Contains("Blue")) 
        { 
            GameManager.gm.blueCompletPlayers += 1; GameManager.gm.blueOutPlayers -= 1;
            if (GameManager.gm.blueCompletPlayers == 4) { ShowCelebration();
            }
        }
        else if (name.Contains("Green"))
        {
            GameManager.gm.greenCompletPlayers += 1; GameManager.gm.greenOutPlayers -= 1;
            if (GameManager.gm.greenCompletPlayers == 4) { ShowCelebration(); 
            }
        }

    }
    void ShowCelebration()
    {
        Canvas.SetActive(false); 
        Final_.SetActive(true);
    }

    public void RescaleandReposition()
    {
        int plsCount = PlayerPiesaList.Count;
        bool isOdd = (plsCount % 2) == 0 ? false : true;

        int extent = plsCount / 2;
        int counter = 0;
        int spriteLayer = 0;

        if (isOdd)
        {
            for(int i = -extent; i <= extent; i++)
            {
                PlayerPiesaList[counter].transform.localScale = new Vector3(pathObjectParent.scale[plsCount - 1], pathObjectParent.scale[plsCount - 1], 1f);
                PlayerPiesaList[counter].transform.position = new Vector3(transform.position.x + (i * pathObjectParent.positionDiference[plsCount - 1]), transform.position.y, 0f);
                counter++;
            }
        }
        else
        {
            for(int i = -extent; i < extent; i++)
            {
                PlayerPiesaList[counter].transform.localScale = new Vector3(pathObjectParent.scale[plsCount - 1], pathObjectParent.scale[plsCount - 1], 1f);
                PlayerPiesaList[counter].transform.position = new Vector3(transform.position.x + (i * pathObjectParent.positionDiference[plsCount - 1]), transform.position.y, 0f);
                counter++;
            }
        }
        for(int i=0;i<PlayerPiesaList.Count;i++)
        {
            PlayerPiesaList[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = spriteLayer;
            spriteLayer++;
        }

    }
}
