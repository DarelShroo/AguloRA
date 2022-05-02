using UnityEngine;
using UnityEngine.UI;

public class textAppFunc : MonoBehaviour
{
    public Text txtAppFunc;

    private string[] appFunc =
    {
        "APP Y FUNCIONES",
        "APP AND FUNCTIONS",
        "APP UND FUNKTIONEN"
    };

    public void Start()
    {
        txtAppFunc.text = appFunc[Lenguage.posIdioma];
    }
}
