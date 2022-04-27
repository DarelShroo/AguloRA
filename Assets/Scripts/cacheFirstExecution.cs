using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cacheFirstExecution : MonoBehaviour
{
    public GameObject contenedorIdiomas;
    private bool activa = false;
    
    void Start()
    {
        
        try
        {
            string path = Application.persistentDataPath + "/preference.txt";

            if (!File.Exists(path))
            {
                //Si la ruta no existe pasamos activa a true
                //para que se visualize el contenedor de idiomas
                activa = true;
            }
            if (!OpenInfo.cambioIdioma)
            {
                //Comprueba si se accede desde otra ventana a la escena idiomas.
                //Si no es a si y es la primera ejecución pasamos activa a true
                //Seteamos el idioma obtenido del fichero
                //Cambiamos la escena a primaryScene
                
                var lineas = File.ReadLines(path);
                var enumerable = lineas.ToList();

                activa = true;
                Lenguage.idioma = enumerable[0];
                SceneManager.LoadScene(1);
            }
            else
            {
                activa = true;
            }
        }catch(Exception e){}
    }

    void Update()
    {
        //Actualizamos la visibilidad del contendor de idiomas
        contenedorIdiomas.SetActive(activa);
    }


    public void saveData(string idioma)
    {
        try
        {
            //Guardamos las preferencias de idioma en un fichero
            
            string path = Application.persistentDataPath + "/preference.txt";
            File.WriteAllText(path, idioma);
            
            //Seteamos los valores a false para que no se produzcan saltos de escenas
            //inesperados desde las otras ventanas hacia la de idiomas
            OpenInfo.cambioIdioma = false;
            activa = false;
        }
        catch (Exception e)
        {
        }
    }
}
