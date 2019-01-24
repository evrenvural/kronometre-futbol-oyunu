using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SesVeBilgi : MonoBehaviour
{
    public GameObject panel;
    public Text textBir, textIki;
    public Button butonBir, butonIki, gotit;

    bool panelAcikMi=false;
    bool panelYazisiIlkEkran = true;

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
