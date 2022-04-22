using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textMenuBlack : MonoBehaviour
{

    public Text visitas;

    public Text cambioCli;

    public Text appFunc;

    public Text apoyoIns;

    public Text idiomas;

    public Text legal;

    private string[] textVisitas =
    {
        "visitas",
        "visits",
        "besucht"
    };
    
    private string[] textCambioCli =
    {
        "cambio climatico",
        "climate change",
        "Klimawandel"
    };
    private string[] textAppFunc =
    {
        "app y funciones",
        "app and functions",
        "App und Funktionen"
    };
    
    private string[] textApoyoIns =
    {
        "apoyo institucional",
        "institutional support",
        "institutionelle Unterstützung"
    };
    
    private string[] textIdiomas =
    {
        "idiomas",
        "Sprachen",
        "languages"
    };
    
    private string[] textoLegal =
    {
        "texto legal",
        "legal text",
        "Rechtstext"
    };

    // Start is called before the first frame update
    void Start()
    {
        string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
        int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;

        visitas.text = textVisitas[posIdioma].ToUpper();
        cambioCli.text = textCambioCli[posIdioma].ToUpper();
        appFunc.text = textAppFunc[posIdioma].ToUpper();
        apoyoIns.text = textApoyoIns[posIdioma].ToUpper();
        idiomas.text = textIdiomas[posIdioma].ToUpper();
        legal.text = textoLegal[posIdioma].ToUpper();

        if (idioma == "de")
        {
            visitas.fontSize = 26;
            cambioCli.fontSize = 26;
            appFunc.fontSize =26;
            apoyoIns.fontSize = 26;
            idiomas.fontSize =26;
            legal.fontSize = 26;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
