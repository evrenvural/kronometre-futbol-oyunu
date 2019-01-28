using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeamsKontrol1 : MonoBehaviour
{
    public Text textSpiker;
    public Text[] team;
    public Text[] skor;
    public Button btnStart, btnContinue;
    Kontrol1 kontrol1;
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
        kontrol1 = obje.GetComponent<Kontrol1>();

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
        skor1 = Kontrol1.skor1;
        skor2 = Kontrol1.skor2;
    }

    void MaciBitir()
    {
        if (skor1 >= kactaBiter || skor2 >= kactaBiter) // Eğer maç bittiyse
        {
            if (!macBitti)
            {
                kontrol1.enabled = false;

                btnStart.gameObject.SetActive(false);

                siraGosterici.enabled = false;
                macBitti = true;
                StartCoroutine(macBittiSpiker());

            }

        }
    }

    public void Continue()
    {
        if (Reklam.interstitial.IsLoaded())
        {
            Reklam.interstitial.Show();
        }
        BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().Play();
          SceneManager.LoadScene(0);
        
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

    bool MacKazanildiMi()
    {
        return skor1 > skor2;
    }
}
