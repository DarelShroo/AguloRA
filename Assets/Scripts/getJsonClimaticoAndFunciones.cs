using System;
using System.Collections;
using easyar;
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
        //Variables públicas serializadas   
        [SerializeField]
        public RawImage imagen;

        [SerializeField]
        public GameObject imgGameObject;
        
        [SerializeField]
        public TextMeshProUGUI textMeshProObject;
        
        [SerializeField]
        public GameObject imgCarga;
        
        [SerializeField]
        public Text textBanner;
        
        [SerializeField]
        public GameObject scrollArea;
        
        //Variables privadas
        private string descripcion;
        private Texture texture;
        private string img_url;
        private Uri urlClimatico = new Uri("https://app.agulopuntoinfo.es/wp-json/agulo/v1/get-climatico?lang=");
        private Uri urlFunciones= new Uri("https://app.agulopuntoinfo.es/wp-json/agulo/v1/get-funciones?lang=");
        private Uri url;
        private ResetStateCheckBox _resetStateCheckBox;
        
        private string[] textBannerClimatico = new[]
        {
            //Texto Banner Cambio Climatico
            "CAMBIO CLIMATICO",
            "CLIMATE CHANGE",
            "KLIMAWANDEL"
        }; 
        
        private string[] textBannerAppFunciones = new[]
        {
            //Texto banner APP Y FUNCIONES
            "APP Y FUNCIONES",
            "APP AND FUNCTION",
            "APP UND FUNKTIONEN"
        }; 
        void Awake()
        {
            getTextCambioClimatico();
        }

        private void Start()
        {
            //_resetStateCheckBox.Reset();
        }


        [RuntimeInitializeOnLoadMethod]
        public void getTextCambioClimatico()
        {
            //Obtenemos el número de escena en la que nos encontramos
            int nEscena = SceneManager.GetActiveScene().buildIndex;
            
            //Comrobamos el índice de la escena para saber como tratar el json
            url = nEscena == 4 ? urlClimatico : urlFunciones;
            
            //Seteamos el texto  del banner de la escena según su idioma y la escena en la que nos encontramos
            textBanner.text = (nEscena == 4) ? textBannerClimatico[Lenguage.posIdioma] : textBannerAppFunciones[Lenguage.posIdioma];
            Debug.Log(nEscena + "numnero de escena");
            //Inicializamos la petición al gestor de contenidos
            StartCoroutine(makeRequest());
            //Inicializamos la obtención de la textura desde el gestor de contenidos para posteriormente convertirla a imagen
            StartCoroutine(makeRequestImage());
        }

        [RuntimeInitializeOnLoadMethod]

        IEnumerator makeRequest()
        {
            //Realizamos una petición al servidor
                UnityWebRequest request = UnityWebRequest.Get(url + Lenguage.idioma);
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    //La petición falla
                    Debug.Log(request.error);
                }
                else
                {
                    //Si la petición es satisfactoria intentamos serializar el objeto y traernos el json del gestor de contenidos.
                    var objeto =
                        JsonConvert.DeserializeObject<ObjectImgAndText>(request.downloadHandler.text);
                    //Filtramos los datos traidos
                    descripcion = objeto.descripcion
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
                    //Seteamos la url de la imágen
                    img_url = objeto.imagen;
                }
           
        }
        [RuntimeInitializeOnLoadMethod]
        IEnumerator makeRequestImage()
        {
            //Realiza una petición al servidor
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
                scrollArea.SetActive(true);
                imgCarga.SetActive(false);
            }
        }
    }
}