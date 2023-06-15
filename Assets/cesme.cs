using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cesme : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LoadManager.instance.LoadNextLevel("RedScene");
    }
}
