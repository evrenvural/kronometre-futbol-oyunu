using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Kontrol : MonoBehaviour
{
    public Image[] image;
    public Sprite[] sayilar;
    TimeSpan ts;
    Stopwatch stopwatch;


    void Start()
    {
        stopwatch = new Stopwatch();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        KronometreKontrol();
      
    }

    void KronometreKontrol()
    {
        if (stopwatch.IsRunning)
        {
            ts = stopwatch.Elapsed;
            int saniyeBir = ts.Seconds % 10;
            int saniyeIki = ts.Seconds / 10;
            int saliseBir = ts.Milliseconds & 10;
            int saliseIki = ts.Milliseconds / 100;
            SayilaraGoreImageAta(saliseBir, image[0]);
            SayilaraGoreImageAta(saliseIki, image[1]);
            SayilaraGoreImageAta(saniyeBir, image[2]);
            SayilaraGoreImageAta(saniyeIki, image[3]);
        }
    }

    void SayilaraGoreImageAta(int sayi, Image image)
    {
        switch (sayi)
        {
            case 0:
                image.sprite = sayilar[0];
                break;
            case 1:
                image.sprite = sayilar[1];
                break;
            case 2:
                image.sprite = sayilar[2];
                break;
            case 3:
                image.sprite = sayilar[3];
                break;
            case 4:
                image.sprite = sayilar[4];
                break;
            case 5:
                image.sprite = sayilar[5];
                break;
            case 6:
                image.sprite = sayilar[6];
                break;
            case 7:
                image.sprite = sayilar[7];
                break;
            case 8:
                image.sprite = sayilar[8];
                break;
            case 9:
                image.sprite = sayilar[9];
                break;
            default:
                image.sprite = sayilar[0];
                break;
        }
    }

    public void KronometreBaslatDurdur()
    {
        if (!stopwatch.IsRunning)
        {
            stopwatch.Start();
        }
        else
        {
            stopwatch.Stop();
        }
    }
}
