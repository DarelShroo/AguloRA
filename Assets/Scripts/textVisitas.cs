using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class textVisitas : MonoBehaviour
{
    public Text textBanner;
    public Text textLugares;
    public Text textPersonajes;
    public Text textArquitectura;
    public Text textHistoriaAb;
    public Text textTradiciones;
    public Text textIniciarVisitas;
    
    private string[] banner = new []
    {
        "Visitas",
        "Visit",
        "Besuchen Sie"
    };

    private string[] lugares = new []
    {
        "Lugares",
        "Places",
        "Orte"
    };
    
    private string[] personajes = new []
    {
        "Personajes",
        "Characters",
        "Zeichen"
    };

    private string[] arquitectura = new[]
    {
        "Arquitectura",
        "Architecture",
        "Architektur"
    };

    private string[] historiaAb = new[]
    {
        "Historia Aborigen",
        "Aboriginal History",
        "Geschichte der Aborigines"
    };

    private string[] tradiciones = new[]
    {
        "Tradiciones",
        "Traditions",
        "Traditionen"
    };
    
    private string[] iniciarVisitas = new[]
    {
        "Iniciar Visita",
        "Start Visit",
        "Start Besuch"
    };
    
    void Start()
    {
        string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
        int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;
        
        textBanner.text = banner[posIdioma].ToUpper();
        textLugares.text = lugares[posIdioma].ToUpper();
        textPersonajes.text = personajes[posIdioma].ToUpper();
        textArquitectura.text = arquitectura[posIdioma].ToUpper();
        textHistoriaAb.text = historiaAb[posIdioma].ToUpper();
        textTradiciones.text  = tradiciones[posIdioma].ToUpper();
        textIniciarVisitas.text = iniciarVisitas[posIdioma];


        if (idioma == "de")
        {
            textLugares.fontSize = 14;
            textPersonajes.fontSize = 14;
            textArquitectura.fontSize = 14;
            textHistoriaAb.fontSize = 14;
            textTradiciones.fontSize  = 14;
        }
    }
}
