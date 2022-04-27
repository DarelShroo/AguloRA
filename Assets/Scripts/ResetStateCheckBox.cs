using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetStateCheckBox : MonoBehaviour
{
    
    private string[] clickParada = new []
    {
        "Clica sobre una Parada ...",
        "Click on a stop ...",
        "Klicken Sie auf eine Haltestelle ..."
    };

    public void Reset()
    {
        CheckboxsState.instance.Lugares = false;
        CheckboxsState.instance.Personajes = false;
        CheckboxsState.instance.Arquitectura = false;
        CheckboxsState.instance.Tradiciones = false;
        CheckboxsState.instance.HistoriaAborigen = false;
        
        Paradas.active.Clear();
    }

    public void ResetParadas(Text text)
    {
        Paradas.active.Clear();
        
        string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
        int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;
        
        text.text = clickParada[posIdioma];
    }
}
