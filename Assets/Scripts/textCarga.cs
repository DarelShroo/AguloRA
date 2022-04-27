using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textCarga : MonoBehaviour
{
    public Text cargando;

    private string[] textCargando =
    {
        "Cargando ...",
        "Loading ...",
        "Laden ..."
    };
    
    // Start is called before the first frame update
    void Start()
    {
        string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
        int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;
        
        cargando.text = textCargando[posIdioma];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
