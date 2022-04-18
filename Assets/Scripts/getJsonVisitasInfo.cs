using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


namespace DefaultNamespace
{
    public class getJsonVisitasInfo : MonoBehaviour
    {
        private string descripcion;
        public RawImage imagen;
        private Texture texture;
        private string img_url;
        private Uri url = new  Uri("https://app.agulopuntoinfo.es/wp-json/agulo/v1/get-paradas?lang=");
        public GameObject imgGameObject;
        public TextMeshProUGUI textDescripcion;
        //public TextMeshProUGUI textSaludo;
        public Text titulo;
        public GameObject imgCarga;
        private string extra;
        private string slug;
        private String id_parada;
        public string idioma;
        // called zero
        void Awake()
        {
            getTextCambioClimatico();
        }

        
        [RuntimeInitializeOnLoadMethod]
        public void getTextCambioClimatico()
        {
            if (Lenguage.idioma == null)
            {
                Lenguage.idioma = "es";
            }
            //TODO descomentar linea videoCarga
            
            //videoCarga.SetActive(false);
            StartCoroutine(makeRequest());
            StartCoroutine(makeRequestImage());
            //videoCarga.SetActive(true);
            
     
        }

        [RuntimeInitializeOnLoadMethod]

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
                        Debug.Log(("valor open info -> "+name.Replace("\n", "")));
                        Debug.Log(("valor original -> " +data.titulo));
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
                            .Replace("</span>", "</font-weight>");
                        textDescripcion.text = descripcion;
                        titulo.text = data.titulo;
                        // textSaludo.text = json[0].saludo;
                        // slug = json[0].slug;
                        // id_parada = json[0].id_parada;
                        img_url = data.imagen;
                    }
                }
            }
        }
        [RuntimeInitializeOnLoadMethod]

        IEnumerator makeRequestImage()
        {
            yield return new WaitForSeconds(2);
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(img_url);
            yield return request.SendWebRequest();
            
            if (request.result != UnityWebRequest.Result.Success )
            {
                Debug.Log(request.error);
            }
            else
            {
                texture =  ((DownloadHandlerTexture)request.downloadHandler).texture;
                imagen.texture = texture;
                imgGameObject.SetActive(true);
                imagen.SetAllDirty();
            }
            imgCarga.SetActive(false);
        }
    }
}