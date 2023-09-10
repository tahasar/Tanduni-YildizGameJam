using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkurGec : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LoadManager.instance.LoadNextLevel("BaltaMap");
    }
}
