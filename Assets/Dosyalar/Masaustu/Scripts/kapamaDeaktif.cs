using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapamaDeaktif : MonoBehaviour
{
    public GameObject kapamaEkran;

    public void Trigger()
    {
        kapamaEkran.SetActive(false);
    }
}
