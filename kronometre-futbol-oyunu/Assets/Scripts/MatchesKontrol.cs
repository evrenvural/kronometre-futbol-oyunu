using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchesKontrol : MonoBehaviour
{
    public Text[] textTeam;
    string[] takimIsimleri;

    int takimSayisi;

    void Start()
    {
        takimSayisi = PlayerPrefs.GetInt("takimSayisi");
        takimIsimleri = new string[takimSayisi];

        
        IlkDegerAta();
        DefaultTakimlariGir();
        TakimlariKar();
        DiziyiTextlereAta();
    }
    void IlkDegerAta()
    {
        for (int i = 0; i < 16; i++)
        {
            textTeam[i].text = "";
        }
    }
    
    void DefaultTakimlariGir()
    {
        takimIsimleri[0] = "Galatasaray";
        takimIsimleri[1] = "Barcelona";
        takimIsimleri[2] = "Real Madrid";
        takimIsimleri[3] = "Arsenal";
        takimIsimleri[4] = "Liverpool";
        takimIsimleri[5] = "Man Utd";
        takimIsimleri[6] = "Monaco";
        takimIsimleri[7] = "Beşiktaş";
        takimIsimleri[8] = "Milan";
        takimIsimleri[9] = "Juventus";
        takimIsimleri[10] = "Fenerbahçe";
        takimIsimleri[11] = "Atletico Madrid";
        takimIsimleri[12] = "Ajax";
        takimIsimleri[13] = "Celtic";
        takimIsimleri[14] = "Villareal";
        takimIsimleri[15] = "Benfica";
    }

    void DiziyiTextlereAta()
    {
        for (int i = 0; i < takimSayisi; i++)
        {
            textTeam[i].text = takimIsimleri[i];
        }
    }

    void TakimlariKar()
    {
        for (int i = 0; i < takimSayisi; i++)
        {
            string temp = takimIsimleri[i];
            int rndm = Random.Range(0, takimSayisi);
            takimIsimleri[i] = takimIsimleri[rndm];
            takimIsimleri[rndm] = temp;
        }
    }

    public void Continue(int sayi)
    {
        SceneManager.LoadScene(sayi);
        PlayerPrefs.SetString("rakipTakim", SecilenTakiminRakibi());
    }

    string SecilenTakiminRakibi()
    {
        int sayi = 0;
        for (int i = 0; i < takimSayisi; i++)
        {
            if (takimIsimleri[i]==PlayerPrefs.GetString("secilenTakim"))
            {
                if (i%2==0)
                {
                    sayi = i + 1;
                }
                else
                {
                    sayi = i - 1;
                }
            }
        }
        return takimIsimleri[sayi];
    }
}


