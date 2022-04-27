using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textMapaScene : MonoBehaviour
{
    public Text textBanner;
    
    public Text textActivarAr;
    
    
    private string[] banner = new []
    {
        "Visitas",
        "Visit",
        "Besuchen Sie"
    };
    
    private string[] activarAr = new[]
    {
        "ACTIVAR LA REALIDAD AUMENTADA",
        "ACTIVATE AUGMENTED REALITY",
        "AUGMENTED REALITY AKTIVIEREN"
    };

    // Start is called before the first frame update
    void Start()
    {
        string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
        int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;
        
        textBanner.text = banner[posIdioma].ToUpper();
        textActivarAr.text = activarAr[posIdioma];
    }
}
