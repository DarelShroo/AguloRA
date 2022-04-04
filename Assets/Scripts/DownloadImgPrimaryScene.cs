using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DownloadImgPrimaryScene : MonoBehaviour
{
    // Start is called before the first frame update
     private string descripcion;
        public RawImage imagen;
        private Texture texture;
        private string img_url;
        public GameObject imgGameObject;

        public string idioma;
        // called zero
        void Awake()
        {
            getTextCambioClimatico();
        }

        
        [RuntimeInitializeOnLoadMethod]
        public void getTextCambioClimatico()
        {
            StartCoroutine(makeRequestImage());
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
