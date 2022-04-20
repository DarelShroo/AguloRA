using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class CheckStateTracking : MonoBehaviour
{
    [SerializeField]
    public GameObject objeto;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            string path = Application.persistentDataPath + "/paradasVisitadas.txt";
            
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            
            if (objeto.activeSelf && objeto.name == OpenInfo.name.Replace("\n", ""))
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

                if (!existe)
                {
                    File.WriteAllText(path, getText(enumerable) + objeto.name + "\n");
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
