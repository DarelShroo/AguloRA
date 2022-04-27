using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textVisitSceneAr : MonoBehaviour
{
    public Text banner;
    public Text mapa;
    public Text info;
    
    private string[] textBanner = new []
    {
        "Visitas",
        "Visit",
        "Besuchen Sie"
    };

    private string[] textMapa =
    {
        "MAPA",
        "MAP",
        "KARTE"
    };

    private string[] textInfo =
    {
        "INFORMACIÓN",
        "INFORMATION",
        "INFORMATIONEN"
    };
    // Start is called before the first frame update
    void Start()
    {
        string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
        int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;
        
        banner.text = textBanner[posIdioma].ToUpper();
        mapa.text = textMapa[posIdioma].ToUpper();
        info.text = textInfo[posIdioma].ToUpper();
    }
}
