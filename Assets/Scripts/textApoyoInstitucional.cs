using UnityEngine;
using UnityEngine.UI;

public class textApoyoInstitucional : MonoBehaviour
{
    public Text textBanner;
    public Text textTitProyecto;
    public Text textProyecto;
    public Text textTitTitular;
    public Text textTitular;
    public Text textTitpromotor;
    public Text textTitfinanciadores;
    public Text textFi;

    private string[] banner = new[]
    {
        "APOYO INSTITUCIONAL",
        "INSTITUTIONAL SUPPORT",
        "INSTITUTIONELLE UNTERSTÜTZUNG"
    };
    
    private string[] titProyecto = new[]
    {
        "Proyecto:",
        "Project:",
        "Projekt"
    };

    private string[] proyecto = new[]
    {
        "Desarrollo de Itinerario Paisajístico de Agulo",
        "Development of the Landscape Itinerary of Agulo",
        "Entwicklung der Landschaftsroute von Agulo"
    };

    private string[] titTitular = new[]
    {
        "Titular:",
        "Holder:",
        "Halterung:"
    };

    private string[] titular = new[]
    {
        "Ayuntamiento de Agulo",
        "Agulo City Hall",
        "Stadtrat von Agulo"
    };

    private string[] promotor = new[]
    {
        "PROMOTOR",
        "DEVELOPER",
        "ENTWICKLER"
    };
    
    private string[] financiadores = new[]
    {
        "FINANCIADORES",
        "FINANCERS",
        "FINANZIERER"
    };


    private string[] textFinal = new[]
    {
        "Proyecto financiado conforme a la Estrategia de Desarrollo Local Participativo de la Gomera " +
        "(medida 19.2 Leader del Programa de Desarrollo Rural de Canarias)",
        
        "Project financed under the Local Participative Development Strategy of " +
        "La Gomera (measure 19.2 Leader of the Rural Development Program of the Canary Islands).",
        
        "Im Rahmen der Strategie zur partizipativen lokalen Entwicklung von La Gomera finanziertes Projekt " +
        "(Maßnahme 19.2 Leader des Programms zur Entwicklung des ländlichen Raums auf den Kanarischen Inseln)."
    };
    void Start()
    {
        textBanner.text = banner[Lenguage.posIdioma]; 
        textTitProyecto.text = titProyecto[Lenguage.posIdioma];
       textProyecto.text = proyecto[Lenguage.posIdioma];
       textTitTitular.text = titTitular[Lenguage.posIdioma];
       textTitular.text = titular[Lenguage.posIdioma];
       textTitpromotor.text = promotor[Lenguage.posIdioma];
       textTitfinanciadores.text = financiadores[Lenguage.posIdioma];
       textFi.text = textFinal[Lenguage.posIdioma];

       if (Lenguage.idioma == "de")
       {
           textBanner.fontSize = 14;
       }
    }
}
