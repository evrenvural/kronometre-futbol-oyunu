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

    bool MacKazanildiMi()
    {
        return skor1 > skor2;
    }

    public void Continue(int ileri)
    {
        BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().Play();
        int takimSayisi = PlayerPrefs.GetInt("takimSayisi");
        PlayerPrefs.SetInt("takimSayisi", takimSayisi / 2);
        GameObject.FindGameObjectWithTag("reklamtag").GetComponent<Reklam>().ReklamiGoster();
        if (MacKazanildiMi() && takimSayisi/2 != 1) // Kazandın İleri
        {
            SceneManager.LoadScene(ileri);
        }
        else // Son Maç ya da elendin
        {
            if (MacKazanildiMi())//kazandın
            {
                PlayerPrefs.SetInt("macKazanildiMi", 0);
            }
            else//elendin
            {
                PlayerPrefs.SetInt("macKazanildiMi", 1);
            }
            SceneManager.LoadScene(4);
        }
    }

    IEnumerator macBittiSpiker()
    {
        yield return new WaitForSeconds(1.5f);

        if (MacKazanildiMi())
        {
            textSpiker.text = spiker.MacBitti() + team[0].text;
        }
        else
        {
            textSpiker.text = spiker.MacBitti() + team[1].text;
        }

        
        btnContinue.gameObject.SetActive(true);
    }
}
