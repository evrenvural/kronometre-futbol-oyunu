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
    public Sprite[] spriteStart;
    public Sprite[] sayilar;
    public Button btnStart, btnDuranTop, btnPenalti;
    public Image siraGosterici;
    public Text tskor1, tskor2;
    public Text textSpiker;
    public float y;
    public GameObject objeSpiker;
    
    

    int saniyeBir=0, saniyeIki=0, saliseBir=0, saliseIki=0;
    static public int skor1=0, skor2=0;
    string evSahibi, deplasman;
    bool siraBende = true;
    bool frikikVuruldu = false, penaltiVuruldu = false;
    
    
    TimeSpan ts;
    Stopwatch stopwatch;
    Vector3 vector2;
    Image imgButtonStart, imgButtonDuranTop, imgButtonPenalti;
    Spiker spiker;
    

    void Start()
    {
       
        imgButtonStart = btnStart.GetComponent<Image>();
        imgButtonDuranTop = btnDuranTop.GetComponent<Image>();
        imgButtonPenalti = btnPenalti.GetComponent<Image>();
        evSahibi = PlayerPrefs.GetString("secilenTakim");
        deplasman = PlayerPrefs.GetString("rakipTakim");
        skor1 = 0;
        skor2 = 0;
        stopwatch = new Stopwatch();
        vector2 = new Vector3(0, y,0);
        spiker = objeSpiker.GetComponent<Spiker>();
    }

    
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
            saliseBir = ts.Milliseconds % 10;
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
            textSpiker.text = evSahibi + spiker.Atak(); //spiker
            imgButtonStart.sprite = spriteStart[1];
            stopwatch.Start();
        }
        else // Sıra Bende
        {
            imgButtonStart.sprite = spriteStart[0];
            stopwatch.Stop();
            KuralKontrol();
            if (!Frikik() && !Penalti())
            {
                if (!Gol())
                {
                    textSpiker.text = spiker.Kaptiriyor();//SPİKER
                }
                siraGosterici.transform.position -= vector2;
                btnStart.enabled = false;
                siraBende = false;
                if (!macBittiMi())
                {
                    StartCoroutine(BilgisayariOynat());
                }
            }
        }
    }

    IEnumerator BilgisayariOynat()
    {
        imgButtonStart.sprite = spriteStart[2];
            yield return new WaitForSeconds(1);
            textSpiker.text = deplasman + spiker.Atak(); //Spiker
            stopwatch.Start();
            int zaman = Random.Range(1, 4);
            yield return new WaitForSeconds(zaman);
            stopwatch.Stop();
            KuralKontrol();
            if (Frikik())
            {
                textSpiker.text = spiker.DuranTop(); //Spiker
                yield return new WaitForSeconds(1);
                FrikikVur();
                zaman = Random.Range(1, 4);
                yield return new WaitForSeconds(zaman);
                FrikikVur();
            }
            if (Penalti())
            {
                textSpiker.text = spiker.Penalti(); //Spiker
                yield return new WaitForSeconds(1);
                PenaltiVur();
                zaman = Random.Range(1, 4);
                yield return new WaitForSeconds(zaman);
                PenaltiVur();
            }
            siraGosterici.transform.position += vector2;
            siraBende = true;
            btnStart.enabled = true;
            imgButtonStart.sprite = spriteStart[0];
            if (!Penalti() && !Frikik() && !Gol())
            {
                if (!frikikVuruldu && !penaltiVuruldu)
                {
                    textSpiker.text = spiker.Kaptiriyor(); // SPiker

                }
            }
            frikikVuruldu = false;
            penaltiVuruldu = false;
            UnityEngine.Debug.Log("Girdik");
     
        
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
            saliseBir == 8 && saliseIki == 8;
    }

    void KuralKontrol()
    {
        if (Gol())
        {
            textSpiker.text = spiker.Gol(); // Spiker
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
            textSpiker.text = evSahibi + spiker.DuranTop(); //Spiker
            btnStart.gameObject.SetActive(false);
            btnDuranTop.gameObject.SetActive(true);
        }
        if (Penalti() && siraBende)
        {
            textSpiker.text = spiker.Penalti(); //Spiker
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
        imgButtonPenalti.sprite = spriteStart[1];
        if (!stopwatch.IsRunning)
        {
            stopwatch.Start();
            textSpiker.text = spiker.DuranTopVur(); //Spiker
        }
        else
        {
            stopwatch.Stop();
            if (PenaltiGolMu())
            {
                textSpiker.text = spiker.Gol(); //Spiker
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
            else
            {
                textSpiker.text = spiker.DuranTopKacirdi(); // Spiker
            }
            imgButtonPenalti.sprite = spriteStart[0];
            btnStart.gameObject.SetActive(true);
            btnPenalti.gameObject.SetActive(false);

            // Sırayı Devret
            if (siraBende)
            {

                siraGosterici.transform.position -= vector2;
                
                btnStart.enabled = false;
                siraBende = false;
                if (!macBittiMi())
                {
                    StartCoroutine(BilgisayariOynat());
                }
            }
            else
            {
                penaltiVuruldu = false;
            }

        }
    }
    public void FrikikVur()
    {
        imgButtonDuranTop.sprite = spriteStart[1];
        if (!stopwatch.IsRunning)
        {
            textSpiker.text = spiker.DuranTopVur(); // Spiker
            stopwatch.Start();
        }
        else
        {
            stopwatch.Stop();
            if (FrikikGolMu())
            {
                textSpiker.text = spiker.Gol(); // Spiker
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
            else
            {
                textSpiker.text = spiker.DuranTopKacirdi(); // Spiker
            }
            imgButtonDuranTop.sprite = spriteStart[0];
            btnStart.gameObject.SetActive(true);
            btnDuranTop.gameObject.SetActive(false);
            
            // Sırayı Devret
            if (siraBende)
            {
                
                siraGosterici.transform.position -= vector2;
                btnStart.enabled = false;
                siraBende = false;
                if (!macBittiMi())
                {
                    StartCoroutine(BilgisayariOynat());
                }
            }
            else
            {
                frikikVuruldu = false;
            }
           
        }
    }

    bool macBittiMi()
    {
        return skor1 >= 1 || skor2 >= 1; //KACTA BİTER
    }

}

