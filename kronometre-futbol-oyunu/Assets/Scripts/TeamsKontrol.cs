using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeamsKontrol : MonoBehaviour
{
    public Text[] team;
    public Text[] skor;
    public Button btnStart, btnContinue;
    Kontrol kontrol;
    public GameObject obje;

    int skor1 = 0, skor2 = 0;
    public int kactaBiter;
    void Start()
    {
        kontrol = obje.GetComponent<Kontrol>();

        team[0].text = PlayerPrefs.GetString("secilenTakim");
        team[1].text = PlayerPrefs.GetString("rakipTakim");
        
    }

    // Update is called once per frame
    void Update()
    {
        GuncelSkorAl();
        MaciBitir();
    }

    void GuncelSkorAl()
    {
        skor1 = Kontrol.skor1;
        skor2 = Kontrol.skor2;
    }

    void MaciBitir()
    {
        if (skor1 >= kactaBiter || skor2 >= kactaBiter) // Eğer maç bittiyse
        {
            btnStart.gameObject.SetActive(false);
            btnContinue.gameObject.SetActive(true);
            kontrol.enabled = false;
        }
    }

    public void Continue(int sayi)
    {
        SceneManager.LoadScene(sayi);
        int takimSayisi = PlayerPrefs.GetInt("takimSayisi");
        PlayerPrefs.SetInt("takimSayisi", takimSayisi / 2);
    }
}
