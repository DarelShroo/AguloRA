using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.SceneManagement;


namespace DefaultNamespace
{
    public class getJsonClimaticoAndFunciones : MonoBehaviour
    {
        private string descripcion;
        public RawImage imagen;
        private Texture texture;
        private string img_url;
        private Uri urlClimatico = new Uri("https://app.agulopuntoinfo.es/wp-json/agulo/v1/get-climatico?lang=");
        private Uri urlFunciones= new Uri("https://app.agulopuntoinfo.es/wp-json/agulo/v1/get-funciones?lang=");
        private Uri url;
        public GameObject imgGameObject;
        public TextMeshProUGUI textMeshProObject;
        public GameObject videoCarga;
        public string idioma;
        // called zero
        void Awake()
        {
            getTextCambioClimatico();
        }

        
        [RuntimeInitializeOnLoadMethod]
        public void getTextCambioClimatico()
        {
            if (SceneManager.GetActiveScene().buildIndex == 4 )
            {
                url = urlClimatico;
            }
            else
            {
                url = urlFunciones;
            }
            
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
            
                UnityWebRequest request = UnityWebRequest.Get(url + Lenguage.idioma);
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    var cambio_climatico =
                        JsonConvert.DeserializeObject<ObjectImgAndText>(request.downloadHandler.text);
                    descripcion = cambio_climatico.descripcion
                        .Replace("<p>", "")
                        .Replace("</p>", "")
                        .Replace("&#8211;", "- ")
                        .Replace("&nbsp;", "\n")
                        .Replace("<li>", "*")
                        .Replace("</li>", "</line-height>")
                        .Replace("<ul>", "")
                        .Replace("</ul>", "")
                        .Replace("<strong>", "<b>")
                        .Replace("</strong>", "</b>")
                        .Replace("<p dir=" + '"' + "ltr" + '"' + " data-placeholder=" + '"' + "Traducción" + '"' + ">",
                            "")
                        .Replace(
                            "<p id=" + '"' + "tw-target-text" + '"' + " class=" + '"' +
                            "tw-data-text tw-text-large XcVN5d tw-ta" + '"' + " dir=" + '"' + "ltr" + '"' +
                            " data-placeholder=" + '"' + "Traducción" + '"' + ">", "")
                        .Replace(
                            "<p class=" + '"' + "tw-data-text tw-text-large XcVN5d tw-ta" + '"' + " dir=" + '"' +
                            "ltr" + '"' + " data-placeholder=" + '"' + "Traducción" + '"' + ">", "\n")
                        .Replace("<span class=" + '"' + "Y2IQFc" + '"' + " lang=" + '"' + "en" + '"' + ">",
                            "<font-weight=400>")
                        .Replace("<span style=" + '"' + "font-weight: 400;" + '"' + ">", "<font-weight=400>")
                        .Replace(
                            "<li style=" + '"' + "font-weight: 400;" + '"' + " aria-level=" + '"' + "1" + '"' + ">",
                            "* <line-height=120%><font-weight=400>")
                        .Replace("</span>", "</font-weight>");
                    Debug.Log("<p class=" + '"' + "tw-data-text tw-text-large XcVN5d tw-ta" + '"' + "dir=" + '"' +
                              "ltr" + '"' + " data-placeholder=" + '"' + "Traducción" + '"' + ">");
                    textMeshProObject.text = descripcion;
                    img_url = cambio_climatico.imagen;
                
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
        }
    }
}