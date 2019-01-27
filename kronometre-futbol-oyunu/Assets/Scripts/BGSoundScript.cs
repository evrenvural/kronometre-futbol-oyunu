using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundScript : MonoBehaviour
{
    public AudioClip butonClickSes;

    private static BGSoundScript instance = null;
    public static BGSoundScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance !=null && instance !=this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ButonClickSesi()
    {
        BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(butonClickSes,1);
    }
}
