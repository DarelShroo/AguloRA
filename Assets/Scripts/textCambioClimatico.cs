using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textCambioClimatico : MonoBehaviour
{
    public Text tituloCambioClimatico;

    private string[] cambioClimatico =
    {
        "CAMBIO CLIMATICO",
        "CLIMATE CHANGE",
        "KLIMAWANDEL"
    };
    // Start is called before the first frame update
    void Start()
    {
        string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
        int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;

        tituloCambioClimatico.text = cambioClimatico[posIdioma];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
