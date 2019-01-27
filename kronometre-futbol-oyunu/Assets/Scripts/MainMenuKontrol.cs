using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuKontrol : MonoBehaviour
{
    AudioSource butonClickSesi;
    public AudioClip ses;
    public static bool acik = true;
    public Sprite[] sprtSes;
    public GameObject goSes;
    Image imgSes;

    void Start()
    {
        butonClickSesi = GetComponent<AudioSource>();
        imgSes = goSes.GetComponent<Image>();
        SesKontrol();
    }

    public void SahneyeGit(int sayi)
    {
        butonClickSesi.PlayOneShot(ses);
        SceneManager.LoadScene(sayi);
        PlayerPrefs.SetInt("takimSayisi", 16);
    }

    public void SesAcKapa()
    {
        if (acik) //Kapa
        {
            BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0;
            acik = false;
            imgSes.sprite = sprtSes[1];

        }
        else //AC
        {
            BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0.5f;
            acik = true;
            imgSes.sprite = sprtSes[0];
        }
    }
    void SesKontrol()
    {
        if (!MainMenuKontrol.acik) //Kapa
        {
            BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0;
            MainMenuKontrol.acik = false;
            imgSes.sprite = sprtSes[1];
        }
        else //AC
        {
            BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0.5f;
            MainMenuKontrol.acik = true;
            imgSes.sprite = sprtSes[0];
        }
    }
}
