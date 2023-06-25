using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZarR : MonoBehaviour
{
    [SerializeField] Sprite[] numberSprits;
    [SerializeField] SpriteRenderer numerHolder;
    [SerializeField] SpriteRenderer rollZarAnim;
    [SerializeField] int numbGot;

    Coroutine generateRandomZar;
    public int outPiese;
    
   
    public void OnMouseDown()
    {
       generateRandomZar= StartCoroutine(RoolZar());
        
    }

    IEnumerator RoolZar()
    {
        yield return new WaitForEndOfFrame();
        if (GameManager.gm.CanZarRoll)
        {
            GameManager.gm.CanZarRoll=false;
            numerHolder.gameObject.SetActive(false);
            rollZarAnim.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            numbGot = Random.Range(0, 6);
            numerHolder.sprite = numberSprits[numbGot];
            numbGot += 1;

            GameManager.gm.numberOfSteptToMove= numbGot;
            GameManager.gm.zarR = this;

            numerHolder.gameObject.SetActive(true);
            rollZarAnim.gameObject.SetActive(false);
            yield return new WaitForEndOfFrame();

            if (GameManager.gm.zarR == GameManager.gm.manageZarR[0]) { outPiese = GameManager.gm.yellowOutPlayers; }
            else if (GameManager.gm.zarR == GameManager.gm.manageZarR[1]) { outPiese = GameManager.gm.redOutPlayers; }
            else if (GameManager.gm.zarR == GameManager.gm.manageZarR[2]) { outPiese = GameManager.gm.blueOutPlayers; }
            else if (GameManager.gm.zarR == GameManager.gm.manageZarR[3]) { outPiese = GameManager.gm.greenOutPlayers; }

            if (GameManager.gm.numberOfSteptToMove != 6 && outPiese == 0)
            {
                GameManager.gm.CanZarRoll = true;
                GameManager.gm.selfZar = false;
                GameManager.gm.transferZar = true;
                yield return new WaitForSeconds(0.5f);
                GameManager.gm.RollZarManager();
            }
            


            if (generateRandomZar != null)
            {
                StopCoroutine(RoolZar());
            }
        }
    }
}
