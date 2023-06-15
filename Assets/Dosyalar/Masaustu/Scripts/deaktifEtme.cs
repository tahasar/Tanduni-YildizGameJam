using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deaktifEtme : MonoBehaviour
{
    public GameObject pic;

    public void Trigger()
    {
            pic.SetActive(false);       
    }
}
