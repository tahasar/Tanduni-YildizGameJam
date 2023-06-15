using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceManager : MonoBehaviour
{

    public Sound[] sounds;
    public static VoiceManager instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        } 
        
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.playOnAwake = false;
        }

        
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "SherlockMap")
        {
            InvokeRepeating("Sahne3",5,0);
        }
        
        if (SceneManager.GetActiveScene().name == "ZombieScene")
        {
            InvokeRepeating("Sahne6",3,0);
        }
        
        if (SceneManager.GetActiveScene().name == "SpecularMap")
        {
            InvokeRepeating("Sahne7",1.5f,0);
        }
        
        if (SceneManager.GetActiveScene().name == "ParkurMap")
        {
            InvokeRepeating("Sahne11",2f,0);
        }
        
        if (SceneManager.GetActiveScene().name == "BaltaMap")
        {
            InvokeRepeating("Sahne12",2f,0);
            InvokeRepeating("Sahne13",16f,0);
        }
        
        if (SceneManager.GetActiveScene().name == "RedScene")
        {
            InvokeRepeating("Sahne9",0.5f,0);
            InvokeRepeating("Sahne10",8f,0);
        }
        
        if (SceneManager.GetActiveScene().name == "PixelScene")
        {
            InvokeRepeating("Sahne15",1f,0);
        }
        
        if (SceneManager.GetActiveScene().name == "Masaustu")
        {
            InvokeRepeating("Masaustu",1f,0);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Play("sahne3");
        }
    }

    public void Play(string audioName)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == audioName);
        s.source.Play();
    }

    public void Stop(string audioName)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == audioName);
        s.source.Stop();
        
    }
    
    /////////////////////////////////////////////////////////////////////////////

    public void Sahne1()
    {
        Play("sahne1");
    }
    
    public void Sahne2()
    {
        Play("sahne2");
    }
    
    public void Sahne3()
    {
        Play("sahne3");
    }
    
    public void Sahne4()
    {
        Play("sahne4");
    }
    
    public void Sahne5()
    {
        Play("sahne5");
    }
    
    public void Sahne6()
    {
        Play("sahne6");
    }
    
    public void Sahne7()
    {
        Play("sahne7");
    }
    
    public void Sahne8()
    {
        Play("sahne8");
    }
    
    public void Sahne9()
    {
        Play("sahne9");
    }
    
    public void Sahne10()
    {
        Play("sahne10");
    }
    
    public void Sahne11()
    {
        Play("sahne11");
    }
    
    public void Sahne12()
    {
        Play("sahne12");
    }
    
    public void Sahne13()
    {
        Play("sahne13");
    }
    
    public void Sahne14()
    {
        Play("sahne14");
    }
    
    public void Sahne15()
    {
        Play("sahne15");
    }
    
    public void Sahne16()
    {
        Play("sahne16");
    }
    
    public void Sahne17()
    {
        Play("sahne17");
    }
    
    public void Sahne18()
    {
        Play("sahne18");
    }
    
    public void Sahne19()
    {
        Play("sahne19");
    }
    
    public void Sahne20()
    {
        Play("sahne20");
    }
    
    public void Masaustu()
    {
        Play("masaustu");
    }
}
