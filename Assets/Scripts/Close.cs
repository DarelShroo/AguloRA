using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject _avisoGps;
    public void Start()
    {
    
    }

    public void closeWindow(GameObject aviso)
    {
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.location.status == LocationServiceStatus.Stopped)
        {
            _avisoGps.SetActive(true);
        }
    }
}
