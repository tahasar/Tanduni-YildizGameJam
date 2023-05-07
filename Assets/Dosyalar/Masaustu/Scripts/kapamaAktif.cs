using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapamaAktif : MonoBehaviour
{
    public GameObject kapamaEkran;

    public void Trigger()
    {
        if (kapamaEkran.activeInHierarchy == false)
        {
            kapamaEkran.SetActive(true);

        }
        else kapamaEkran.SetActive(false);
    }
}
