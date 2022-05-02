using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;

namespace DefaultNamespace
{
    public class getJsonVisitasInfo : MonoBehaviour
    {
        //Variables públicas serializadas   
        [SerializeField]
        public RawImage imagen;
        
        [SerializeField]
        public GameObject imgGameObject;
        
        [SerializeField]
        public TextMeshProUGUI textDescripcion;
        
        [SerializeField]
        public Text titulo;
        
        [SerializeField]
        public GameObject imgCarga;
        
        
        //Variables privadas
        private string descripcion;
        private Texture texture;
        private string img_url;
        private Uri url = new  Uri("https://app.agulopuntoinfo.es/wp-json/agulo/v1/get-paradas?lang=");
        private string extra;
        private string slug;
        private String id_parada;

        // called zero
        void Awake()
        {
            getTextCambioClimatico();
        }

        
        [RuntimeInitializeOnLoadMethod]
        public void getTextCambioClimatico()
        {
            //Realizamos una petición al gestor de contenidos para traernos el json
            StartCoroutine(makeRequest());
            
            //Realizamos una petición al servidor para traernos la imágen
            StartCoroutine(makeRequestImage());
        }

        [RuntimeInitializeOnLoadMethod]
        IEnumerator makeRequest()
        {
            //Realizamos la petición al servidor.
            UnityWebRequest request = UnityWebRequest.Get(url+Lenguage.idioma);
            yield return request.SendWebRequest();
                
            if (request.result != UnityWebRequest.Result.Success )
            {
                //La petición falla
                Debug.Log(request.error);
            }
            else
            {
                //La petición ha sido satisfactoria
                var json =
                    JsonConvert.DeserializeObject<List<ObjectInfoParada>>(request.downloadHandler.text);

                //Recorremos todos los objetos deserializados
                foreach (var data in json)
                {
                    //Tratamos de buscar si coincide con el nombre del objeto seteado en OpenInfo.name
                    if (data.titulo.Replace(" ", "").Equals(OpenInfo.name.Replace("\n", "").Replace(" ","")))
                    {
                        descripcion = data.descripcion
                            .Replace("<p>", "")
                            .Replace("</p>", "")
                            .Replace("&#8211;", "- ")
                            .Replace("&nbsp;", "\n")
                            .Replace("<li>", "*")
                            .Replace("</li>", "</line-height>")
                            .Replace("<ul>", "")
                            .Replace("</ul>", "")
                            .Replace("<strong>", "<b>")
                            .Replace("</strong>","</b>")
                            .Replace("<p dir="+'"'+"ltr"+'"'+" data-placeholder="+'"'+"Traducción"+'"'+">","")
                            .Replace("<p id="+'"'+"tw-target-text"+'"'+ " class="+'"'+"tw-data-text tw-text-large XcVN5d tw-ta"+'"'+ " dir="+'"'+"ltr"+'"'+ " data-placeholder="+'"'+"Traducción"+'"'+">", "")
                            .Replace("<p class="+'"'+"tw-data-text tw-text-large XcVN5d tw-ta"+'"' +" dir="+'"'+"ltr"+'"'+" data-placeholder="+'"'+"Traducción"+'"'+">","\n")
                            .Replace("<span class="+'"'+"Y2IQFc"+'"'+ " lang="+'"'+"en"+'"'+">","<font-weight=400>")
                            .Replace("<span style="+'"'+"font-weight: 400;"+'"'+">", "<font-weight=400>")
                            .Replace("<li style="+'"'+"font-weight: 400;"+'"' +" aria-level="+'"'+"1"+'"'+">", "* <line-height=120%><font-weight=400>")
                            .Replace("</span>", "</font-weight>")
                            .Replace("<p style="+'"'+"text-align: center;"+'"'+">","<align=center>");
                        textDescripcion.text = descripcion;
                        titulo.text = data.titulo;
                        img_url = data.imagen;
                    }
                }
            }
        }
        [RuntimeInitializeOnLoadMethod]

        IEnumerator makeRequestImage()
        {
            //Realizamos una petición al servidor
            yield return new WaitForSeconds(2);
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(img_url);
            yield return request.SendWebRequest();
            
            if (request.result != UnityWebRequest.Result.Success )
            {
                //La petición falla
                Debug.Log(request.error);
            }
            else
            {
                //Construimos la imágen
                texture =  ((DownloadHandlerTexture)request.downloadHandler).texture;
                imagen.texture = texture;
                imgGameObject.SetActive(true);
                imagen.SetAllDirty();
                imgCarga.SetActive(false);
            }
        }
    }
}