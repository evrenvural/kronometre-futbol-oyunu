using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeamsKontrol : MonoBehaviour
{
    public Text textSpiker;
    public Text[] team;
    public Text[] skor;
    public Button btnStart, btnContinue;
    Kontrol kontrol;
    public GameObject obje;
    public GameObject objeSpiker;
    public Image siraGosterici;
    Spiker spiker;
    

    int skor1 = 0, skor2 = 0;
    public int kactaBiter;
    bool macBitti = false;

    void Start()
    {
        spiker = objeSpiker.GetComponent<Spiker>();
        kontrol = obje.GetComponent<Kontrol>();
        
        team[0].text = PlayerPrefs.GetString("secilenTakim");
        team[1].text = PlayerPrefs.GetString("rakipTakim");

        textSpiker.text = spiker.MacBaslayacak(); //SPİKER
    }
    
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
            if (!macBitti)
            {
                kontrol.enabled = false;
                
                btnStart.gameObject.SetActive(false);
                
                siraGosterici.enabled = false;
                macBitti = true;
                StartCoroutine(macBittiSpiker());
                
            }
       
        }
    }

    public void Continue(int sayi)
    {
        SceneManager.LoadScene(sayi);
        int takimSayisi = PlayerPrefs.GetInt("takimSayisi");
        PlayerPrefs.SetInt("takimSayisi", takimSayisi / 2);
    }

    IEnumerator macBittiSpiker()
    {
        yield return new WaitForSeconds(1.5f);
        textSpiker.text = spiker.MacBitti();
        btnContinue.gameObject.SetActive(true);
    }
}
