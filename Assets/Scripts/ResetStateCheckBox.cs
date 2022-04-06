using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStateCheckBox : MonoBehaviour
{
    public void Reset()
    {
        CheckboxsState.instance.Lugares = false;
        CheckboxsState.instance.Personajes = false;
        CheckboxsState.instance.Arquitectura = false;
        CheckboxsState.instance.Tradiciones = false;
        CheckboxsState.instance.HistoriaAborigen = false;
    }
}
