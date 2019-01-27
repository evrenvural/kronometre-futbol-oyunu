using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SesVeBilgi : MonoBehaviour
{
    public GameObject panel;
    public Text textBir, textIki;
    public Button butonBir, butonIki, gotit;
    public Image imgSes;
    public Sprite[] sprtSes;

    bool panelAcikMi=false;
    bool panelYazisiIlkEkran = true;
    AudioSource ses;

    int ilkOynanisKontrol = 0;

    void Start()
    {
        BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().Stop();
        ses = GetComponent<AudioSource>();
        SesKontrol();
        ilkOynanisKontrol += PlayerPrefs.GetInt("ilkOynanis");
        if (ilkOynanisKontrol == 0)
        {
           panel.SetActive(true);
           panelAcikMi = true;
          
            PlayerPrefs.SetInt("ilkOynanis", 1);
        }
    }

    void SesKontrol()
    {
        if (!MainMenuKontrol.acik) //Kapa
        {
            BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0;
            MainMenuKontrol.acik = false;
            imgSes.sprite = sprtSes[1];
            ses.volume = 0;
        }
        else //AC
        {
            BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0.5f;
            MainMenuKontrol.acik = true;
            imgSes.sprite = sprtSes[0];
            ses.volume = 1;
        }
    }

    public void SesAcKapa()
    {
        if (MainMenuKontrol.acik) //Kapa
        {
            BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0;
            MainMenuKontrol.acik = false;
            imgSes.sprite = sprtSes[1];
            ses.volume = 0;
        }
        else //AC
        {
            BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0.5f;
            MainMenuKontrol.acik = true;
            imgSes.sprite = sprtSes[0];
            ses.volume = 1;
        }
    }

    public void OpenPanel()
    {
        if (panelAcikMi) // Paneli Kapat
        {
            panel.SetActive(false);
            panelAcikMi = false;
        }
        else // Paneli Aç
        {
            panel.SetActive(true);
            panelAcikMi= true;
        }
        
    }

    public void PanelYaziDegistir()
    {
        if (panelYazisiIlkEkran) // İkinci ekrana geç
        {
            gotit.gameObject.SetActive(true);
            butonBir.gameObject.SetActive(false);
            butonIki.gameObject.SetActive(true);
            textBir.enabled = false;
            textIki.enabled = true;
            panelYazisiIlkEkran = false;
        }
        else //İlk ekrana dön
        {
            gotit.gameObject.SetActive(false);
            butonBir.gameObject.SetActive(true);
            butonIki.gameObject.SetActive(false);
            textBir.enabled = true;
            textIki.enabled = false;
            panelYazisiIlkEkran = true;
        }
    }
}
