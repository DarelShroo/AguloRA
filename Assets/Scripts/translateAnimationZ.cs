using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class translateAnimationZ : MonoBehaviour
{
    public GameObject quad;
    void Update()
    {
        float maxValue = 0.600f;
        try
        {
            var vectorUp = Vector3.up * (Time.deltaTime / 20);
            var vectorDown = Vector3.down * 0.60f;

            var y = quad.transform.position.y;
            if (y > maxValue)
            {
                quad.transform.Translate(vectorDown);
            }
            else
            {
                quad.transform.Translate(vectorUp);
            }
        }
        catch (Exception e)
        {}
    }
}
