using UnityEngine;
using UnityEngine.UI;


public class SelectParada : MonoBehaviour
{

    public Toggle lugares;

    public Toggle personajes;

    public Toggle arquitectura;

    public Toggle tradiciones;

    public Toggle historiaAborigen;

    public GameObject iniciarVisita;
    
    private bool imgActive;
    
    private int nSelectOff = 0;
    
    private void Awake()
    {
        iniciarVisita.SetActive(false);
    }
    
    public void addOrRemoveParada()
    {
        Lenguage.idioma = (Lenguage.idioma == null) ? "es" : Lenguage.idioma;
    }

    public void paradasAmostrar()
    {
        foreach (var parada in Paradas.instance.listaParadas)
        {
            Parada p = (Parada) parada;
            if (Paradas.active.Contains(p.Tipo.ToLower()))
            {
                p.Visible = true;
            }
            else
            {
                p.Visible = false;
            }
        }
    }

    public void setToggle(Toggle toggle)
    {
        if (toggle.isOn)
        {
            nSelectOff++;
            list(toggle.name.ToLower(), true);
            Paradas.active.Add(toggle.name.ToLower());
        }
        else
        {
            nSelectOff--;
            list(toggle.name.ToLower(), false);
            Paradas.active.Remove(toggle.name.ToLower());
        }
    }

    private void list(string nombre, bool active)
    {
        switch (nombre)
        {
            case "lugares": 
                CheckboxsState.instance.Lugares = active;
                break;
            case "personajes": 
                CheckboxsState.instance.Personajes = active;
                break;
            case "arquitectura": 
                CheckboxsState.instance.Arquitectura = active;
                break;
            case "tradiciones": 
                CheckboxsState.instance.Tradiciones = active;
                break;
            case "historiaaborigen": 
                CheckboxsState.instance.HistoriaAborigen = active;
                break;
        }
    }

    private void listener(bool state, Toggle toggle)
    {
        if (state)
        {
            toggle.isOn = true;
        }
    }

    private void Start()
    {
        iniciarVisita.SetActive(false);
    }

    private void Update()
    {
        if (nSelectOff == 0)
        {
            imgActive = false;
        }
        else
        {
            imgActive = true;
        }
        
        listener(CheckboxsState.instance.Lugares, lugares);
        listener(CheckboxsState.instance.Personajes, personajes);
        listener(CheckboxsState.instance.Arquitectura, arquitectura);
        listener(CheckboxsState.instance.Tradiciones, tradiciones);
        listener(CheckboxsState.instance.HistoriaAborigen, historiaAborigen);

        iniciarVisita.SetActive(imgActive);
    }
}