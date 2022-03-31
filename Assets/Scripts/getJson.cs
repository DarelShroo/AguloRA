using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;
using UnityEditor;


namespace DefaultNamespace
{
    [InitializeOnLoad] 
    public class getJson : MonoBehaviour
    {
        private string descripcion;
        public RawImage imagen;
        private Texture texture;
        private string img_url;
        public Uri url = new Uri("https://app.agulopuntoinfo.es/wp-json/agulo/v1/get-climatico?lang=");
        public GameObject imgGameObject;
        public TextMeshProUGUI textMeshProObject;
        
        // called zero
        void Awake()
        {
            getTextCambioClimatico();
        }

        
        [RuntimeInitializeOnLoadMethod]
        public void getTextCambioClimatico()
        {
            StartCoroutine(makeRequest());
            StartCoroutine(makeRequestImage());
        }

        [RuntimeInitializeOnLoadMethod]

        IEnumerator makeRequest()
        {
            if (Lenguage.idioma == null)
            {
                Lenguage.idioma = "es";
            }

            UnityWebRequest request = UnityWebRequest.Get(url+Lenguage.idioma);
            Debug.Log(Lenguage.idioma);
            yield return request.SendWebRequest();
                
            if (request.result != UnityWebRequest.Result.Success )
            {
                Debug.Log(request.error);
            }
            else
            {
                var cambio_climatico =
                    JsonConvert.DeserializeObject<textCambioClimatico>(request.downloadHandler.text);
                descripcion = cambio_climatico.descripcion
                    .Replace("<p>", "")
                    .Replace("</p>", "")
                    .Replace("&#8211;", "- ")
                    .Replace("&nbsp;", "\n")
                    .Replace("<li>", "*")
                    .Replace("</li>", "")
                    .Replace("<ul>", "")
                    .Replace("</ul>", "")
                    .Replace("<span style="+'"'+"font-weight: 400;"+'"'+">", "<font-weight=400>")
                    .Replace("</span>", "</font-weight>");
                
                textMeshProObject.text = descripcion;
                img_url = cambio_climatico.imagen;
            }
        }
        [RuntimeInitializeOnLoadMethod]

        IEnumerator makeRequestImage()
        {
            yield return new WaitForSeconds(1);
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