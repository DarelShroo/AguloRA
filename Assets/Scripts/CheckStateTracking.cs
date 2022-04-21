using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DefaultNamespace;
using easyar;
using Mapbox.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using Object = System.Object;
using VideoPlayer = UnityEngine.Video.VideoPlayer;

public class CheckStateTracking : MonoBehaviour
{
    [SerializeField]
    public GameObject[] objetos; 
    private  VideoPlayer vid ;

    private string urlVideo = "";
    void Start()
    {

    }

    public void Awake()
    {
        StartCoroutine(makeRequest());
    }

    public void Update()
    {
        try
        {
            foreach (var objeto in objetos)
            {

                if (objeto.activeSelf && objeto.name == OpenInfo.name.Replace("\n", ""))
                {
                    objeto.transform.Find("Quad").gameObject.SetActive(true);
                }
                else
                {
                    objeto.transform.Find("Quad").gameObject.SetActive(false);
                }
            }
        }
        catch (Exception e)
        {
        }
    }
    
        IEnumerator makeRequest()
        {
            string url = "https://app.agulopuntoinfo.es/wp-json/agulo/v1/get-modelos"; 
            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            
           
            if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    var json =
                        JsonConvert.DeserializeObject<List<ObjectVid>>(request.downloadHandler.text);
                    foreach (var objectVid in json)
                    {
                        if (objectVid.titulo.Equals(OpenInfo.name.Replace("\n", "")))
                        {

                            if (!objectVid.video.Equals(""))
                            {

                                urlVideo = objectVid.video;
                            }
                            else
                            {
                                
                            }
                        }
                    }
                }
            try
            {
                string path = Application.persistentDataPath + "/paradasVisitadas.txt";
            
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                foreach (var objeto in objetos)
                {
                    if (objeto.name.Equals(OpenInfo.name.Replace("\n", "")))
                    {
                        var lineas = File.ReadLines(path);
                        var enumerable = lineas as string[] ?? lineas.ToArray();

                        bool existe = false;
                        foreach (var parada in enumerable)
                        {
                            if (parada == objeto.name)
                            {
                                existe = true;
                            }
                        }
                        
                        vid = objeto.transform.Find("Quad").gameObject.GetComponent<VideoPlayer>();
                        vid.url = urlVideo;
                        vid.audioOutputMode = VideoAudioOutputMode.AudioSource;
                        vid.EnableAudioTrack (0, true);
                        vid.SetDirectAudioVolume(0, 1);
                        vid.SetDirectAudioMute(0,false);
                        vid.audioOutputMode = VideoAudioOutputMode.Direct;
                        vid.Prepare ();

                        if (!existe)
                        {
                            File.WriteAllText(path, getText(enumerable) + objeto.name + "\n");
                        } 
                    }

              
                } 
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

        }

    private string getText(IEnumerable<string> lineas)
    {
        string text = "";
        foreach (var linea in lineas)
        {
            text += linea+"\n";
        }

        return text;
    }
}
