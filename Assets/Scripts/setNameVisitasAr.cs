using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class setNameVisitasAr : MonoBehaviour
{
    public Text text;
    public void Update()
    {
        text.text = OpenInfo.name.Replace("\n","");
    }
}
