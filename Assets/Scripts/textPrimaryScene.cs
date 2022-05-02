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
        textVisitas.text = visita[Lenguage.posIdioma];
        textCambioCli.text = cambioCli[Lenguage.posIdioma];
        textAppFunc.text = appFunc[Lenguage.posIdioma];
        textApoyoIns.text = apoyoIns[Lenguage.posIdioma];
        textIdioma.text = idiomas[Lenguage.posIdioma];

        if (Lenguage.idioma == "de")
        {
            textVisitas.fontSize =14;
            textCambioCli.fontSize = 14;
            textAppFunc.fontSize = 14;
            textApoyoIns.fontSize = 14;
            textIdioma.fontSize = 14;
        }
    }
}
