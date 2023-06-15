using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkurGec : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LoadManager.instance.LoadNextLevel("BaltaMap");
    }
}
