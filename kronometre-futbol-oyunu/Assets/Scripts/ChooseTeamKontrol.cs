using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseTeamKontrol : MonoBehaviour
{
    public Button[] btnTeam;
    public Text secilenTakim;
    Text text;
    public Button btnContinue;
    public static bool ilkGelis = true;
    public Text title;

    void Start()
    {
        TitleYazdir();
        AyniTakimKontrol();
    }

    void TitleYazdir()
    {
        if (MainMenuKontrol.turnuva)
        {
            title.text = "SELECT YOUR TEAM";
        }
        else
        {
            if (ilkGelis)
            {
                title.text = "SELECT THE FIRST PLAYER'S TEAM";
            }
            else
            {
                title.text = "SELECT THE SECOND PLAYER'S TEAM";
            }
        }
    }

    public void Choose(int sayi)
    {
        btnContinue.gameObject.SetActive(true);
       
        text = btnTeam[sayi].GetComponentInChildren<Text>();
        secilenTakim.text = text.text;
       
        PlayerPrefs.SetInt("secilenButonSayi", sayi);
    }

    public void Continue(int sahneNumarasi)
    {
        if (MainMenuKontrol.turnuva)
        {
            PlayerPrefs.SetString("secilenTakim", secilenTakim.text.ToString());
            SceneManager.LoadScene(sahneNumarasi);
        }
        else
        {
            if (ilkGelis)
            {
                PlayerPrefs.SetString("secilenTakim", secilenTakim.text.ToString());
                SceneManager.LoadScene(1);
                ilkGelis = false;
            }
            else
            {
                PlayerPrefs.SetString("rakipTakim", secilenTakim.text.ToString());
                SceneManager.LoadScene(5);
                ilkGelis = true;
            }
        }
    }

    void AyniTakimKontrol()
    {
        if (!ilkGelis)
        {
            int sayi = PlayerPrefs.GetInt("secilenButonSayi");

            btnTeam[sayi].enabled = false;
           
        }
    }

    public void Back()
    {
        if (MainMenuKontrol.turnuva)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            if (ilkGelis)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                ilkGelis = true;

                SceneManager.LoadScene(1);
            }
        }
    }

}
