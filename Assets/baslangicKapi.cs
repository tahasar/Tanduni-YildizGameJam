using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baslangicKapi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadManager.instance.LoadNextLevel("SherlockMap");
    }
}
