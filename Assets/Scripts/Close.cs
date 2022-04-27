using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject _avisoGps;

    public void closeWindow(GameObject aviso)
    {
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.location.status == LocationServiceStatus.Stopped)
        {
            _avisoGps.SetActive(true);
        }
    }
}
