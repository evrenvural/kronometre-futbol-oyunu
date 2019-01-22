using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchesKontrol : MonoBehaviour
{
    public Text[] textTeam;
    public Text[] cizgi;
    string[] takimIsimleri;

    int takimSayisi;

    void Start()
    {
        takimSayisi = PlayerPrefs.GetInt("takimSayisi");
        takimIsimleri = new string[16];

        
        IlkDegerAta();
        DefaultTakimlariGir();
        TakimlariKar(takimSayisi);
        DiziyiTextlereAta();
        
    }
    void IlkDegerAta()
    {
        for (int i = 0; i < 16; i++)
        {
            textTeam[i].text = "";
        }
        for (int i = 0; i < 8; i++)
        {
            cizgi[i].text = "";
        }
    }
    
    void DefaultTakimlariGir()
    {
        if (takimSayisi==16)
        {
            takimIsimleri[0] = "GALATASARAY";
            takimIsimleri[1] = "BARCELONA";
            takimIsimleri[2] = "REAL MADRID";
            takimIsimleri[3] = "ARSENAL";
            takimIsimleri[4] = "LIVERPOOL";
            takimIsimleri[5] = "MAN UTD";
            takimIsimleri[6] = "MONACO";
            takimIsimleri[7] = "PSG";
            takimIsimleri[8] = "MILAN";
            takimIsimleri[9] = "JUVENTUS";
            takimIsimleri[10] = "PORTO";
            takimIsimleri[11] = "ATLETICO MADRID";
            takimIsimleri[12] = "AJAX";
            takimIsimleri[13] = "CELTIC";
            takimIsimleri[14] = "VILLAREAL";
            takimIsimleri[15] = "BENFICA";
        }
        else if (takimSayisi==8)
        {
            takimIsimleri[0] = PlayerPrefs.GetString("takim1");
            takimIsimleri[1] = PlayerPrefs.GetString("takim2");
            takimIsimleri[2] = PlayerPrefs.GetString("takim3");
            takimIsimleri[3] = PlayerPrefs.GetString("takim4");
            takimIsimleri[4] = PlayerPrefs.GetString("takim5");
            takimIsimleri[5] = PlayerPrefs.GetString("takim6");
            takimIsimleri[6] = PlayerPrefs.GetString("takim7");
            takimIsimleri[7] = PlayerPrefs.GetString("takim8");
        }
        else if (takimSayisi == 4)
        {
            takimIsimleri[0] = PlayerPrefs.GetString("takim1");
            takimIsimleri[1] = PlayerPrefs.GetString("takim2");
            takimIsimleri[2] = PlayerPrefs.GetString("takim3");
            takimIsimleri[3] = PlayerPrefs.GetString("takim4");
            
        }
        else if (takimSayisi==2)
        {
            takimIsimleri[0] = PlayerPrefs.GetString("takim1");
            takimIsimleri[1] = PlayerPrefs.GetString("takim2");
        }
    }

    void DiziyiKaydet() //BURAYA BAK
    {
        KazananTakimlar();
        PlayerPrefs.SetString("takim1", takimIsimleri[0]);
            PlayerPrefs.SetString("takim2", takimIsimleri[1]);
            PlayerPrefs.SetString("takim3", takimIsimleri[2]);
            PlayerPrefs.SetString("takim4", takimIsimleri[3]);
            PlayerPrefs.SetString("takim5", takimIsimleri[4]);
            PlayerPrefs.SetString("takim6", takimIsimleri[5]);
            PlayerPrefs.SetString("takim7", takimIsimleri[6]);
            PlayerPrefs.SetString("takim8", takimIsimleri[7]);
       
        
    }

    void KazananTakimlar()
    {
        string[] arrayTemp = new string[takimSayisi/2];
        
        int sayac = 0;
        string temp="";

        for (int i = 0; i < takimSayisi; i+=2)
            {
                if (takimIsimleri[i]==PlayerPrefs.GetString("secilenTakim") || takimIsimleri[i+1] == PlayerPrefs.GetString("secilenTakim"))
                    {
                        if (takimIsimleri[i] == PlayerPrefs.GetString("secilenTakim"))
                            {
                                temp = takimIsimleri[i];
                            }
                        else
                            {
                                temp = takimIsimleri[i + 1];
                            }
                    }

                else
                 {
                    int rndmSayi = Random.Range(0, 2);
                    temp = takimIsimleri[i + rndmSayi];
               
                 }

                arrayTemp[sayac] = temp;
                sayac++;

            }
            //Geçici diziyi asıl diziye ata.
            for (int i = 0; i < takimSayisi/2; i++)
            {
                takimIsimleri[i] = arrayTemp[i];
            }
        
      
    }

    void DiziyiTextlereAta()
    {
        
        for (int i = 0; i < takimSayisi; i++)
        {
            textTeam[i].text = takimIsimleri[i];
        }
        for (int i = 0; i < takimSayisi/2; i++)
        {
            cizgi[i].text = "-";
        }
    }

    void TakimlariKar(int takimSayisi)
    {
        for (int i = 0; i < takimSayisi; i++)
        {
            string temp = takimIsimleri[i];
            int rndm = SayiUret(i);
            takimIsimleri[i] = takimIsimleri[rndm];
            takimIsimleri[rndm] = temp;
        }
    }

    int SayiUret(int i)
    {
        int rndm;
        do
        {
            rndm = Random.Range(0, takimSayisi);
        } while (rndm==i);
        return rndm;
    }

    public void Continue(int sayi)
    {
        PlayerPrefs.SetString("rakipTakim", SecilenTakiminRakibi());
        DiziyiKaydet();
        SceneManager.LoadScene(sayi); 
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


