
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spiker : MonoBehaviour
{
    private string[] atak, duranTop, penalti, gol, duranTopVur, duranTopKacirdi, macBitti, macBaslayacak, kaptiriyor;
    int random;
   
    void Start()
    {
        atak = new string[3];
        atak[0] = " IS ATTACKING FROM THE RIGHT";
        atak[1] = " IS PLAYING EFFECTIVE";
        atak[2] = " IS ATTACKING FROM THE LEFT";
        duranTop = new string[2];
        duranTop[0] = "FREEKICK...";
        duranTop[1] = "OH.. TOO HARD FOUL";
        penalti = new string[2];
        penalti[0] = "PENALTY... PE NAL TY";
        penalti[1] = "REFEREE'S POINTING AT WHITE POINT";
        gol = new string[3];
        gol[0] = "GOAAAAALLLLLLLLLL";
        gol[1] = "EXCELLENT SHOT AND PERFECT GOAL"; 
        gol[2] = "WHAT A GOAL";
        duranTopVur = new string[2];
        duranTopVur[0] = "SHOOOOOOTT";
        duranTopVur[1] = "SHOOOT";
        duranTopKacirdi = new string[2];
        duranTopKacirdi[0] = "TOO WEAK SHOT";
        duranTopKacirdi[1] = "MISSED...";
        macBitti = new string[3];
        macBitti[0] = "AND THE MATCH ENDS. WINNING TEAM IS ";
        macBitti[1] = "THE WINNER OF THE DIFFICULT MATCH IS ";
        macBitti[2] = "AWESOME GAME FROM ";
        macBaslayacak = new string[3];
        macBaslayacak[0] = "WE ARE TOGETHER FOR AWESOME THE MATCH";
        macBaslayacak[1] = "HAVE A PERFECT WEATHER TODAY FOR FOOTBALL";
        macBaslayacak[2] = "REFEREE'S CHECKING HIS WATCH";
        kaptiriyor = new string[3];
        kaptiriyor[0] = "DEFENCE IS DOING A GOOD JOB TONIGHT";
        kaptiriyor[1] = "AND.. OUT";
        kaptiriyor[2] = "BALL LOSS";
    }

    public string Atak()
    {
        random = Random.Range(0, 3);
        return atak[random];
    }
    public string DuranTop()
    {
        random = Random.Range(0, 2);
        return duranTop[random];
    }
    public string Penalti()
    {
        random = Random.Range(0, 2);
        return penalti[random];
    }
    public string Gol()
    {
        random = Random.Range(0, 3);
        return gol[random];
    }
    public string DuranTopVur()
    {
        random = Random.Range(0, 2);
        return duranTopVur[random];
    }
    public string DuranTopKacirdi()
    {
        random = Random.Range(0, 2);
        return duranTopKacirdi[random];
    }
    public string MacBitti()
    {
        random = Random.Range(0, 3);
        return macBitti[random];
    }
    public string MacBaslayacak()
    {
        random = Random.Range(0, 3);
        return macBaslayacak[random];
    }
    public string Kaptiriyor()
    {
        random = Random.Range(0, 3);
        return kaptiriyor[random];
    }
}
