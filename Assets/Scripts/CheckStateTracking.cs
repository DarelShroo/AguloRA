
using UnityEngine;

public class CheckStateTracking : MonoBehaviour
{
    public GameObject objeto;

    public GameObject objetoQueHareVisible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objeto.active)
        {
            objetoQueHareVisible.SetActive(true);
        }
    }
}
