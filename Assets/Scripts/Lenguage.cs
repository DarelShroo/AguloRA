using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lenguage : MonoBehaviour
{
    
    public static Lenguage instance;
    public static string idioma = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                //Destroy(gameObject);
            }
        }
    }
    

    public string getIdioma()
    {
        return idioma;
    }
    
    public void setIdioma(string leng)
    {
        idioma = leng;
    }
}
