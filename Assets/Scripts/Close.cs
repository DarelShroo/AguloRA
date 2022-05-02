using UnityEngine;

public class Close : MonoBehaviour
{
    //Esta clase Comprueba si el gps está activo y un método para ocultar un objeto.
    [SerializeField]
    public GameObject _avisoGps;

    public void closeWindow(GameObject aviso)
    {
        //Ocultamos el objeto
        gameObject.SetActive(false);
    }

    public void Update()
    {
        //Comprueba si el usuario tiene activo el gps
        if (Input.location.status == LocationServiceStatus.Stopped)
        {
            //Activa el aviso gps no activo
            //_avisoGps.SetActive(true);
        }
    }
}
