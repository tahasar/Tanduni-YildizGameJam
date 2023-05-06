using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inevitables : MonoBehaviour
{
    public static Inevitables instance;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
