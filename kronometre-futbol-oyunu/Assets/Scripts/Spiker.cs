
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spiker : MonoBehaviour
{
    private string[] atak, duranTop, penalti, gol, duranTopVur, duranTopKacirdi, macBitti;
    int random;
   
    void Start()
    {
        atak = new string[3];
        atak[0] = " sağ taraftan atağa çıkıyor";
        atak[1] = " sol taraftan atağa çıkıyor";
        atak[2] = " orta sahadan atağa çıkıyor";
        duranTop = new string[2];
        duranTop[0] = " tehlikeli yerden frikik kazanıyor";
        duranTop[1] = " uzak noktadan frikik kazanıyor";
        penalti = new string[2];
        penalti[0] = "penaltı.... Bunun adı pe nal tıı";
        penalti[1] = "Aman allahım penaltııı";
        gol = new string[3];
        gol[0] = "goooool allahım goooool";
        gol[1] = "uzak noktadan mükemmel bir şut harika bir gol";
        gol[2] = "Ben bu gole içerim harikaa bir goool";
        duranTopVur = new string[2];
        duranTopVur[0] = "şuuuuuttt";
        duranTopVur[1] = "bir şuuuuut";
        duranTopKacirdi = new string[2];
        duranTopKacirdi[0] = "top dışarda";
        duranTopKacirdi[1] = "nasıl kaçar aman allahım";
        macBitti = new string[3];
        macBitti[0] = "ve maç bitiyor maçın galibi ";
        macBitti[1] = "zor maçı kazanan ";
        macBitti[2] = "ne maçtı ama";
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
}
