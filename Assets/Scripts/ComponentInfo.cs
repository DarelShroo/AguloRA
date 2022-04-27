using System;
using UnityEngine;
using UnityEngine.UI;

public class ComponentInfo : MonoBehaviour
{
    public static ComponentInfo instance;
    
    [SerializeField]
    public Image bannerAr;
    
    [SerializeField]
    public Image flecha;
    
    [SerializeField]
    public Text textActivarAr;
    
    [SerializeField]
    public Text textName;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                //Destroy(gameObject);
            }
        }
    }
    public static ComponentInfo Instance
    {
        get => instance;
        set => instance = value;
    }

    public Image BannerAr
    {
        get => bannerAr;
        set => bannerAr = value;
    }

     public Text TextActivarAr
     {
         get => textActivarAr;
         set => textActivarAr = value;
     }

    public Text TextName
    {
        get => textName;
        set => textName = value;
    }
    
    private string[] clickParada = new []
    {
        "Clica sobre una Parada ...",
        "Click on a stop ...",
        "Klicken Sie auf eine Haltestelle ..."
    };
    
    private void Update()
    {
        bannerAr.color = OpenInfo.colorActivarAr; // Color banner
        textName.text = OpenInfo.Name.Replace("\n","") != "" ?
            OpenInfo.Name.Replace("\n",""):
            clickParada[Lenguage.posIdioma];
        textActivarAr.color = OpenInfo.textActivarAr;
    }
}
