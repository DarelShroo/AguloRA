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
    void Start()
    {
        tituloCambioClimatico.text = cambioClimatico[Lenguage.posIdioma];
    }

}
