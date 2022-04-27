using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textInfoScene : MonoBehaviour
{
    public Text banner;

    public Text cargando;

    private string[] textCargando =
    {
        "Cargando ...",
        "Loading ...",
        "Laden ..."
    };

    
    private string[] textBanner = new[]
    {
        "Visitas",
        "Visit",
        "Besuchen Sie"
    };

    void Start()
    {
        string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
        int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;

        banner.text = textBanner[posIdioma].ToUpper();
        cargando.text = textCargando[posIdioma];
    }
}
