using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Mapbox.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class textActivarAr : MonoBehaviour
{
    //Variables públicas serializadas
    [SerializeField]
    public GameObject _avisoAr;
    
    [SerializeField]
    public GameObject _aviso;
    
    [SerializeField]
    public Text txtSaludo;

    
    [SerializeField]
    public Text activarAr;
    
    [SerializeField]
    public Text avisoGps;
    
    [SerializeField]
    public Text textName;
    
    [SerializeField]
    public GameObject imgCarga;
    
    //Variables privadas
    private bool _textActivarArBool;
    private Uri url = new  Uri("https://app.agulopuntoinfo.es/wp-json/agulo/v1/get-paradas?lang=");
 
    private string[] txtClickParada = new []
    {
        "Clica sobre una Parada ...",
        "Click on a stop ...",
        "Klicken Sie auf eine Haltestelle ..."
    };
    
    private string[] txtActivarAr =
    {
        "ACTIVAR LA REALIDAD AUMENTADA",
        "ACTIVATE AUGMENTED REALITY",
        "AUGMENTED REALITY AKTIVIEREN"
    };

    private string[] txtAvisoGps =
    {
        "Compruebe su conexión a internet y su ubicación e inténtelo de nuevo.",
        "Check your internet connection and location and try again.",
        "Überprüfen Sie Ihre Internetverbindung und Ihren Standort und versuchen Sie es erneut."
    };
    
    void Update()
    {
        if (!OpenInfo.mostrado)
        {
            _aviso.SetActive(true);
            OpenInfo.mostrado = true;
        }


        if (!OpenInfo.Name.Replace("\n", "")
                .Replace(" ", "")
                .Equals(OpenInfo.nombreAnterior.Replace(" ", "")) &&
            !textName.text.Replace(" ", "").Equals(txtClickParada[Lenguage.posIdioma]
                .Replace(" ", "")))
        {
            try
            {
                imgCarga.SetActive(true);
                OpenInfo.nombreAnterior = OpenInfo.Name.Replace("\n", "");

                activarAr.text = txtActivarAr[Lenguage.posIdioma];
                avisoGps.text = txtAvisoGps[Lenguage.posIdioma];

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
                        txtSaludo.text = data.saludo;
                    }
                }
                imgCarga.SetActive(false);
                _avisoAr.SetActive(true);
            }
        }
}
