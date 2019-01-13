using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Kontrol : MonoBehaviour
{
    public Image[] image;
    public Sprite[] sayilar;
    public Button btnStart;
    public Image siraGosterici;
    public Text tskor1, tskor2;

    int saniyeBir, saniyeIki, saliseBir, saliseIki;
    int skor1, skor2;
    bool siraBende = true;

    TimeSpan ts;
    Stopwatch stopwatch;
    Vector3 vector2;

    void Start()
    {
        stopwatch = new Stopwatch();
        vector2 = new Vector3(352.0f, 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
        KronometreKontrol();
        

    }
   
    // Değerler hesaplanır ve imagelara gönderilir.
    void KronometreKontrol()
    {
        if (stopwatch.IsRunning)
        {
            ts = stopwatch.Elapsed;
            saniyeBir = ts.Seconds % 10;
            saniyeIki = ts.Seconds / 10;
            saliseBir = ts.Milliseconds & 10;
            saliseIki = ts.Milliseconds / 100;
            SayilaraGoreImageAta(saliseBir, image[0]);
            SayilaraGoreImageAta(saliseIki, image[1]);
            SayilaraGoreImageAta(saniyeBir, image[2]);
            SayilaraGoreImageAta(saniyeIki, image[3]);
        }
    }   

    // Kronometreden gelen değerlere göre imagelar sayıları gösterir.
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

    public void InsaniOynat()
    {
        if (!stopwatch.IsRunning)
        {
            stopwatch.Start();
        }
        else // Sıra Bende
        {
            stopwatch.Stop();
            siraGosterici.transform.position += vector2;
            siraBende = false;
            btnStart.enabled = false;
            MacKurallariKontrol();
            StartCoroutine(BilgisayariOynat());
            
        }
    }

    IEnumerator BilgisayariOynat()
    {
        if (!siraBende) // Sıra Bilgisayarda
        {
            yield return new WaitForSeconds(1);
            stopwatch.Start();
            int zaman = Random.Range(1, 4);
            yield return new WaitForSeconds(zaman);
            stopwatch.Stop();
            siraGosterici.transform.position -= vector2;
            siraBende = true;
            btnStart.enabled = true;
            MacKurallariKontrol();
        }
    }

    bool Gol()
    {
        return saliseBir == 0 && saliseIki == 0 || saniyeBir == 9 && saniyeIki == 9;
    }

    void MacKurallariKontrol()
    {
        if (Gol())
        {
            if (!siraBende) //Kullanıcı Yeri Not: bool değiştikten sonra bu methot çağrıldığı için ters koydum.
            {
                skor1 = Convert.ToInt16(tskor1.text);
                skor1++;
                tskor1.text = skor1.ToString();
            }
            else // Bilgisayar Yeri
            {
                skor2 = Convert.ToInt16(tskor2.text);
                skor2++;
                tskor2.text = skor2.ToString();
            }
        }
    }
}
