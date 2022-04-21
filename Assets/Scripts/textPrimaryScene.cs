using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

public class textPrimaryScene : MonoBehaviour
{
    public Text textVisitas;

    public Text textCambioCli;

    public Text textAppFunc;

    public Text textApoyoIns;

    public Text textIdioma;


    private string[] visita = new[]
    {
        "VISITAS",
        "VISITS",
        "BESUCHE"
    };
    
    private string[] cambioCli = new []
    {
        "CAMBIO CLIMATICO",
        "CLIMATE CHANGE",
        "KLIMAWANDEL"
    };
    
    private string[] appFunc = new[]
    {
        "APP Y FUNCIONES",
        "APP AND FUNCTIONS",
        "APP UND FUNKTIONEN"
    };

    private string[] apoyoIns = new[]
    {
        "APOYO INSTITICIONAL",
        "INSTITUTIONAL SUPPORT",
        "INSTITUTIONELLE UNTERSTÜTZUNG"
    };
    
    private string[] idiomas = new[]
    {
        "IDIOMAS",
        "LANGUAGES",
        "SPRACHEN"
    };

    // Start is called before the first frame update
    void Start()
    {
        string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
        int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;

        textVisitas.text = visita[posIdioma];
        textCambioCli.text = cambioCli[posIdioma];
        textAppFunc.text = appFunc[posIdioma];
        textApoyoIns.text = apoyoIns[posIdioma];
        textIdioma.text = idiomas[posIdioma];

        if (idioma == "de")
        {
            textVisitas.fontSize =14;
            textCambioCli.fontSize = 14;
            textAppFunc.fontSize = 14;
            textApoyoIns.fontSize = 14;
            textIdioma.fontSize = 14;
        }
    }
}
