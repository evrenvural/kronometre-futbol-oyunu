using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseKontrol : MonoBehaviour
{
    public GameObject win, lose;
    public Text textTakim;

    string takimIsmi;
    int macKazanildiMi;

    void Start()
    {
        int takimSayisi = PlayerPrefs.GetInt("takimSayisi");
        macKazanildiMi = PlayerPrefs.GetInt("macKazanildiMi");
        takimIsmi = PlayerPrefs.GetString("secilenTakim");


        if (takimSayisi<=1 && macKazanildiMi==0) //Win Ekranı
        {
            textTakim.text = takimIsmi;
            win.gameObject.SetActive(true);

        }
        else
        {
            lose.gameObject.SetActive(true);
        }
    }

    public void AnaMenuyeDon(int sayi)
    {
        SceneManager.LoadScene(sayi);
    }

}
