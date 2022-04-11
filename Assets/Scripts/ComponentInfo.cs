using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentInfo : MonoBehaviour
{
    public static ComponentInfo instance;
    public  Image bannerAr;
    public  Image flecha;
    public Text textActivarAr; 
    //public static  Text textActivarAr;
    public Text textName;

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

   /* public Text TextActivarAr
    {
        get => textActivarAr;
        set => textActivarAr = value;
    }*/

    public Text TextName
    {
        get => textName;
        set => textName = value;
    }

    private void Update()
    {
        bannerAr.color = OpenInfo.colorActivarAr; // Color banner
        textName.text = OpenInfo.name.Replace("\n", "");
        textActivarAr.color = OpenInfo.textActivarAr;


        // ComponentInfo.instance.textName.text = name.Replace("\n", ""); // Modifico el texto
        //ComponentInfo.instance.textActivarAr.color = textActivarAr; // modifico el color del texto
    }

}
