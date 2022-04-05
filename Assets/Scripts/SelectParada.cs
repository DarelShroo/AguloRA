using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private Toggle[] _toggles = new Toggle[5];

    private ArrayList nParadas = new ArrayList();

    private bool imgActive;
    // called zero

    private void Awake()
    {
        iniciarVisita.SetActive(false);
    }

    public void addOrRemoveParada()
    {
        _toggles[0] = lugares;
        _toggles[1] = personajes;
        _toggles[2] = arquitectura;
        _toggles[3] = tradiciones;
        _toggles[4] = historiaAborigen;

            if (Lenguage.idioma == null)
            {
                Lenguage.idioma = "es";
            }
            //TODO descomentar linea videoCarga
            //videoCarga.SetActive(false);
            foreach (var toggle in _toggles)
            {
                if (toggle.isOn)
                {
                    switch (toggle.name)
                    {
                        case "LugaresToggle": 
                            //campoFutbol
                            //LaVica
                            nParadas.Add("futbol");
                            nParadas.Add("laVica");
                            Debug.Log(nParadas.Count);
                            break;
                        case "PersonajesToggle": 
                            //hermanosBethencourt
                            //LeoncioBento
                            //cesarinaBento
                            //FélixHerrera
                            //filichristi
                            //PedroSanchez
                            //AntonioJesus
                            break;
                        case "ArquitecturaToggle": 
                            //acequiaPerez
                            //CasaPintorAguiar
                            //ElPescante
                            break;
                        case "TradicionesToggle": 
                            //LosPiques
                            //Hogeras
                            break;
                        case "HistoriaAborigenToggle": 
                            //CuevaAborigen
                            break;
                    }
                }
                
                if (!toggle.isOn)
                {
                    switch (toggle.name)
                    {
                        case "LugaresToggle": 
                            nParadas.Remove("futbol");
                            nParadas.Remove("laVica");
                            break;
                        case "PersonajesToggle": 
                            //hermanosBethencourt
                            //LeoncioBento
                            //cesarinaBento
                            //FélixHerrera
                            //filichristi
                            //PedroSanchez
                            //AntonioJesus
                            break;
                        case "ArquitecturaToggle": 
                            //acequiaPerez
                            //CasaPintorAguiar
                            //ElPescante
                            break;
                        case "TradicionesToggle": 
                            //LosPiques
                            //Hogeras
                            break;
                        case "HistoriaAborigenToggle": 
                            //CuevaAborigen
                            break;
                    }
                }
            }

            int nSelectOff = 0;
            foreach (var toggle  in _toggles)
            {
                if (!toggle.isOn)
                {
                    nSelectOff++;
                }
            }
            
            if (nSelectOff==5)
            {
                imgActive = false;
            }
            else
            {
                imgActive = true;
            }
            //videoCarga.SetActive(true);
           
        }

    private void Start()
    {
        iniciarVisita.SetActive(false);
    }

    private void Update()
    {
        iniciarVisita.SetActive(imgActive);
    }
}
