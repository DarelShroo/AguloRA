using UnityEngine;

public class OpenInfo : MonoBehaviour
{ 
    public static string name = "";
    
    public static Color32 colorActivarAr;
    public static Color32 colorActivarArFlecha;
    public static Color32 textActivarAr = Color.gray;
    public static OpenInfo instance;
    public static string nombreAnterior;
    public static bool mostrado;
    public static bool cambioIdioma;
    

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

    public void Start()
    {
    }


    public void getNameParada(GameObject getNameParada)
    {
        name = getNameParada.GetComponent<TextMesh>().text;
        colorActivarAr = new Color32(189, 107, 153, 200); // color rosado
        colorActivarArFlecha = new Color32(133, 133, 133, 30); // color negro transparente
        textActivarAr = Color.white;
    }

    public void Update()
    {
        
    }
    public static string Name
    {
        get => name;
        set => name = value;
    }

    public static Color32 ColorActivarAr
    {
        get => colorActivarAr;
        set => colorActivarAr = value;
    }

    public static Color32 ColorActivarArFlecha
    {
        get => colorActivarArFlecha;
        set => colorActivarArFlecha = value;
    }

    public static Color32 TextActivarAr
    {
        get => textActivarAr;
        set => textActivarAr = value;
    }

    public static OpenInfo Instance
    {
        get => instance;
        set => instance = value;
    }
}
