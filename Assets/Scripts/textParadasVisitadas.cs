using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class textParadasVisitadas : MonoBehaviour
{
    public Text text;

    private int nParadasVisitadas = -1;

    private int nMasParada = 0;
    // Start is called before the first frame update

    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
            try
            {
                var lineas = File.ReadLines(Application.persistentDataPath + "/paradasVisitadas.txt");
                var enumerable = lineas.ToList();
                nParadasVisitadas= enumerable.Count();
             
                text.text = "Has visitado " + nParadasVisitadas + " lugares de 15.\n" +
                            "¡Estupendo, lo más difícil ya está hecho!";
                nMasParada+= nParadasVisitadas;
            }
            catch (Exception e)
            {
            }
        
    }
}
