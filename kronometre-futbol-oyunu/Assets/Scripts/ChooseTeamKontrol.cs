using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseTeamKontrol : MonoBehaviour
{
    GameObject btnTeam;
    public Text secilenTakim;
    Text text;
    public void Choose(int sayi)
    {
        switch (sayi)
        {
            case 1:
                btnTeam = GameObject.Find("Team1");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 2:
                btnTeam = GameObject.Find("Team2");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 3:
                btnTeam = GameObject.Find("Team3");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 4:
                btnTeam = GameObject.Find("Team4");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 5:
                btnTeam = GameObject.Find("Team5");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 6:
                btnTeam = GameObject.Find("Team6");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 7:
                btnTeam = GameObject.Find("Team7");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 8:
                btnTeam = GameObject.Find("Team8");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 9:
                btnTeam = GameObject.Find("Team9");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 10:
                btnTeam = GameObject.Find("Team10");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 11:
                btnTeam = GameObject.Find("Team11");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 12:
                btnTeam = GameObject.Find("Team12");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 13:
                btnTeam = GameObject.Find("Team13");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 14:
                btnTeam = GameObject.Find("Team14");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 15:
                btnTeam = GameObject.Find("Team15");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;
            case 16:
                btnTeam = GameObject.Find("Team16");
                text = btnTeam.GetComponentInChildren<Text>();
                secilenTakim.text = text.text;
                break;

        }
    }

    public void Continue(int sahneNumarasi)
    {
        PlayerPrefs.SetString("secilenTakim",secilenTakim.text.ToString());
        SceneManager.LoadScene(sahneNumarasi);
    }

}
