using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamsKontrol : MonoBehaviour
{
    public Text[] team;
    public Text[] skor;
    void Start()
    {
        team[0].text = PlayerPrefs.GetString("secilenTakim");
        team[1].text = PlayerPrefs.GetString("rakipTakim");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
