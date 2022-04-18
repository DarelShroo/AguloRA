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

    private void Update()
    {
        bannerAr.color = OpenInfo.colorActivarAr; // Color banner
        textName.text = OpenInfo.name.Replace("\n", "");
        textActivarAr.color = OpenInfo.textActivarAr;
    }
}
