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
        "Languages",
        "Sprachen"
    };
    
    private string[] textoLegal =
    {
        "texto legal",
        "legal text",
        "Rechtstext"
    };

    void Start()
    {
        visitas.text = textVisitas[Lenguage.posIdioma].ToUpper();
        cambioCli.text = textCambioCli[Lenguage.posIdioma].ToUpper();
        appFunc.text = textAppFunc[Lenguage.posIdioma].ToUpper();
        apoyoIns.text = textApoyoIns[Lenguage.posIdioma].ToUpper();
        idiomas.text = textIdiomas[Lenguage.posIdioma].ToUpper();
        legal.text = textoLegal[Lenguage.posIdioma].ToUpper();

        if (Lenguage.idioma == "de")
        {
            visitas.fontSize = 26;
            cambioCli.fontSize = 26;
            appFunc.fontSize =26;
            apoyoIns.fontSize = 26;
            idiomas.fontSize =26;
            legal.fontSize = 26;
        }

    }
}
