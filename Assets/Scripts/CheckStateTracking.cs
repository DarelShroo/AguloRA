
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CheckStateTracking : MonoBehaviour
{
    public GameObject objeto;
    //public TextAsset _textAsset;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            string path = Application.persistentDataPath+"/paradasVisitadas.txt";

            if (objeto.activeSelf && objeto.name == OpenInfo.name.Replace("\n", ""))
            {
                var lineas = File.ReadLines(path);
                var enumerable1 = lineas as string[] ?? lineas.ToArray();
                var enumerable = enumerable1.ToList();
                if (!enumerable.Contains(objeto.name));
                    {
                        File.WriteAllText(path, getText(enumerable1)+objeto.name + "\n");
                    }
            }
        }
        catch (Exception e)
        {
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

    // Update is called once per frame
    void Update()
    {
    }
}
