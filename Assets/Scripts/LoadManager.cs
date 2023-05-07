using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public GameObject blackPanel;

    public Image blackScreen;

    public Animator transition;
    public float transitionTime = 1f;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad0))
        {
            LoadNextLevel("Masaustu");
        }
        
        if (Input.GetKey(KeyCode.Keypad1))
        {
            LoadNextLevel("BaslangicMap");
        }
        
        if (Input.GetKey(KeyCode.Keypad2))
        {
            LoadNextLevel("SherlockMap");
        }
        
        if (Input.GetKey(KeyCode.Keypad3))
        {
            LoadNextLevel("ZombieScene");
        }
        
        if (Input.GetKey(KeyCode.Keypad4))
        {
            LoadNextLevel("SpecularMap");
        }
        
        if (Input.GetKey(KeyCode.Keypad5))
        {
            LoadNextLevel("ParkurMap");
        }
        
        if (Input.GetKey(KeyCode.Keypad6))
        {
            LoadNextLevel("BaltaMap");
        }
        
        //if (Input.GetKey(KeyCode.Keypad7))
        //{
        //    LoadNextLevel("SpecularMap");
        //}
        //
        //if (Input.GetKey(KeyCode.Keypad8))
        //{
        //    LoadNextLevel("BaslangicMap");
        //}
    }

    public void loadBaslangic()
    {
        LoadNextLevel("BaslangicMap");
    }

    public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    public IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
