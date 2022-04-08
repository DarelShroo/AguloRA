using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInfo : MonoBehaviour
{
    public void openInfo(GameObject parada)
    {
        Debug.Log("ghjsdkfbasdioufbhasoz");
        CheckboxsState.NameInfo = parada.GetComponent<TextMesh>().text;
    }
}
