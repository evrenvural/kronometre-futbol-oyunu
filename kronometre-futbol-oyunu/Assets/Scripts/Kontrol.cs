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
    public Button btnStart, btnDuranTop, btnPenalti;
    public Image siraGosterici;
    public Text tskor1, tskor2;

    int saniyeBir=0, saniyeIki=0, saliseBir=0, saliseIki=0;
    static public int skor1=0, skor2=0;
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
            KuralKontrol();
            if (!Frikik() && !Penalti())//Penaltı gelecek
            {
                siraGosterici.transform.position += vector2;
                btnStart.enabled = false;
                siraBende = false;
                StartCoroutine(BilgisayariOynat());
            }
        }
    }

    IEnumerator BilgisayariOynat()
    {
        
        yield return new WaitForSeconds(1);
        stopwatch.Start();
        int zaman = Random.Range(1, 4);
        yield return new WaitForSeconds(zaman);
        stopwatch.Stop();
        KuralKontrol();
        if (Frikik())
        {
            yield return new WaitForSeconds(1);
            FrikikVur();
            zaman = Random.Range(1, 4);
            yield return new WaitForSeconds(zaman);
            FrikikVur();
        }
        if (Penalti())
        {
            yield return new WaitForSeconds(1);
            PenaltiVur();
            zaman = Random.Range(1, 4);
            yield return new WaitForSeconds(zaman);
            PenaltiVur();
        }
        siraGosterici.transform.position -= vector2;
        siraBende = true;
        btnStart.enabled = true;
            
    }

    bool Gol()
    {
        return saliseBir == 0 && saliseIki == 0 || saliseBir == 9 && saliseIki == 9;
    }

    bool Frikik()
    {
        return saliseBir == 0 && saliseIki == 1 ||
            saliseBir == 0 && saliseIki == 2 ||
            saliseBir == 0 && saliseIki == 3 ||
            saliseBir == 0 && saliseIki == 4 ||
            saliseBir == 0 && saliseIki == 5 ||
            saliseBir == 0 && saliseIki == 6 ||
            saliseBir == 0 && saliseIki == 7 ||
            saliseBir == 0 && saliseIki == 8 ||
            saliseBir == 0 && saliseIki == 9;
    }
    bool Penalti()
    {
        return saliseBir == 1 && saliseIki == 1 ||
            saliseBir == 2 && saliseIki == 2 ||
            saliseBir == 3 && saliseIki == 3 ||
            saliseBir == 4 && saliseIki == 4 ||
            saliseBir == 5 && saliseIki == 5 ||
            saliseBir == 6 && saliseIki == 6 ||
            saliseBir == 7 && saliseIki == 7 ||
            saliseBir == 8 && saliseIki == 8 ||
            saliseBir == 9 && saliseIki == 9;
    }

    void KuralKontrol()
    {
        if (Gol())
        {
            if (siraBende) 
            {
                skor1++;
                tskor1.text = skor1.ToString();
            }
            else 
            {
                skor2++;
                tskor2.text = skor2.ToString();
            }
        }
        if (Frikik() && siraBende)
        {
            btnStart.gameObject.SetActive(false);
            btnDuranTop.gameObject.SetActive(true);
        }
        if (Penalti() && siraBende)
        {
            btnStart.gameObject.SetActive(false);
            btnPenalti.gameObject.SetActive(true);
        }
    }

    bool FrikikGolMu()
    {
        return saliseBir == 1 && saliseIki == 1 ||
            saliseBir == 2 && saliseIki == 2 ||
            saliseBir == 3 && saliseIki == 3 ||
            saliseBir == 4 && saliseIki == 4 ||
            saliseBir == 5 && saliseIki == 5 ||
            saliseBir == 6 && saliseIki == 6 ||
            saliseBir == 7 && saliseIki == 7 ||
            saliseBir == 8 && saliseIki == 8 ||
            saliseBir == 0 && saliseIki == 0 ||
            saliseBir == 9 && saliseIki == 9;
    }
    bool PenaltiGolMu()
    {
        return saliseBir % 2 == 0;
    }

    public void PenaltiVur()
    {
        if (!stopwatch.IsRunning)
        {
            stopwatch.Start();
        }
        else
        {
            stopwatch.Stop();
            if (PenaltiGolMu())
            {
                if (siraBende)
                {
                    skor1++;
                    tskor1.text = skor1.ToString();
                }
                else
                {
                    skor2++;
                    tskor2.text = skor2.ToString();
                }
            }

            btnStart.gameObject.SetActive(true);
            btnPenalti.gameObject.SetActive(false);

            // Sırayı Devret
            if (siraBende)
            {

                siraGosterici.transform.position += vector2;
                btnStart.enabled = false;
                siraBende = false;
                StartCoroutine(BilgisayariOynat());
            }

        }
    }
    public void FrikikVur()
    {
        if (!stopwatch.IsRunning)
        {
            stopwatch.Start();
        }
        else
        {
            stopwatch.Stop();
            if (FrikikGolMu())
            {
                if (siraBende)
                {
                    skor1++;
                    tskor1.text = skor1.ToString();
                }
                else
                {
                    skor2++;
                    tskor2.text = skor2.ToString();
                }
            }

            btnStart.gameObject.SetActive(true);
            btnDuranTop.gameObject.SetActive(false);
            
            // Sırayı Devret
            if (siraBende)
            {
               
                siraGosterici.transform.position += vector2;
                btnStart.enabled = false;
                siraBende = false;
                StartCoroutine(BilgisayariOynat());
            }
           
        }
    }

}

