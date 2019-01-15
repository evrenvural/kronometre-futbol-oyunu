using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuKontrol : MonoBehaviour
{
    public void SahneyeGit(int sayi)
    {
        SceneManager.LoadScene(sayi);
        PlayerPrefs.SetInt("takimSayisi", 16);
    }
}
