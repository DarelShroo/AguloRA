using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DefaultNamespace;
using Mapbox.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class textActivarAr : MonoBehaviour
{
    public GameObject _avisoAr;
    public GameObject _aviso;
    public Text textoParada;
    public Text txtActivarAr;
    public Text txtAvisoGps;
    private string nameAnterior;
    public Text textName;
    private bool _textActivarArBool;
    private Uri url = new  Uri("https://app.agulopuntoinfo.es/wp-json/agulo/v1/get-paradas?lang=");
    public GameObject imgCarga;
    private string[] clickParada = new []
    {
        "Clica sobre una Parada ...",
        "Click on a stop ...",
        "Klicken Sie auf eine Haltestelle ..."
    };
    
    private string[] activarAr =
    {
        "ACTIVAR LA REALIDAD AUMENTADA",
        "ACTIVATE AUGMENTED REALITY",
        "AUGMENTED REALITY AKTIVIEREN"
    };

    private string[] avisoGps =
    {
        "Compruebe su conexión a internet y su ubicación e inténtelo de nuevo.",
        "Check your internet connection and location and try again.",
        "Überprüfen Sie Ihre Internetverbindung und Ihren Standort und versuchen Sie es erneut."
    };
    
    // Update is called once per frame
    void Update()
    {
      string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
      int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;

      if (!OpenInfo.mostrado)
      {
          _aviso.SetActive(true);
          OpenInfo.mostrado = true;
      }
      

      if (!OpenInfo.Name.Replace("\n", "").Equals(OpenInfo.nombreAnterior) && !textName.text.Equals(clickParada[posIdioma])) 
            {
                Debug.Log("estoy entrando aqui");
                try
                {
                    imgCarga.SetActive(true);

                    /* bool existe = false;
                     foreach (var parada in paradas)
                     {
                         if (parada.Replace("\n","").Equals(OpenInfo.Name.Replace("\n","")))
                         {
                             existe = true;
                         }
                     }*/
                    
                    //Busca si la parada que ha sido visitada o no
                   // if (!existe)
                    
                        OpenInfo.nombreAnterior = OpenInfo.Name.Replace("\n", "");
                        
                        txtActivarAr.text = activarAr[posIdioma];
                        txtAvisoGps.text = avisoGps[posIdioma];

                        StartCoroutine(makeRequest());
                    
                }
                catch (Exception e)
                {
                }
            }
        
        
}
    
     IEnumerator makeRequest()
        {
            
            UnityWebRequest request = UnityWebRequest.Get(url+Lenguage.idioma);
            yield return request.SendWebRequest();
                
            if (request.result != UnityWebRequest.Result.Success )
            {
                Debug.Log(request.error);
            }
            else
            {
                var json =
                    JsonConvert.DeserializeObject<List<ObjectInfoParada>>(request.downloadHandler.text);

                foreach (var data in json)
                {
                    if (data.titulo.Equals(OpenInfo.name.Replace("\n", "")))
                    {
                        textoParada.text = data.saludo;
                    }
                }
                imgCarga.SetActive(false);
                _avisoAr.SetActive(true);
                
            }
        }
}
