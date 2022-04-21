using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textInfoScene : MonoBehaviour
{
    public Text textBanner;
    private string[] banner = new []
    {
        "Visitas",
        "Visit",
        "Besuchen Sie"
    };
    // Start is called before the first frame update
    void Start()
    {
        string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
        int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;
        
        textBanner.text = banner[posIdioma].ToUpper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
