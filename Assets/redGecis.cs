using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redGecis : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LoadManager.instance.LoadNextLevel("ParkurMap");
    }
}
