using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGecis : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LoadManager.instance.LoadNextLevel("ParkurMap");
    }
}
