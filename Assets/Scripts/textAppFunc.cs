using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textAppFunc : MonoBehaviour
{
    public Text txtAppFunc;

    private string[] appFunc =
    {
        "APP Y FUNCIONES",
        "APP AND FUNCTIONS",
        "APP UND FUNKTIONEN"
    };

    public void Start()
    {
        string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
        int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;

        txtAppFunc.text = appFunc[posIdioma];
    }
}
