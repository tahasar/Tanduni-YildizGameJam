using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcHata : MonoBehaviour
{
    public GameObject hata
        ;

    public void Trigger()
    {
        if (hata.activeInHierarchy == false)
        {
            hata.SetActive(true);

        }

    }
}
