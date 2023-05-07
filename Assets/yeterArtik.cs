using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeterArtik : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LoadManager.instance.LoadNextLevel("ZombieScene");
    }
}
