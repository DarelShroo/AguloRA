using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{
   //Texto nombre paradas por defecto
   private string[] clickParada = new []
   {
      "Clica sobre una Parada ...",
      "Click on a stop ...",
      "Klicken Sie auf eine Haltestelle ..."
   };

   public void switchScene(int scene)
   {
      //Cambiamos al número de escena que
      //se pasa por parámetro
      SceneManager.LoadScene(scene);
   }
   public void switchSceneactivarAr(Text text)
   {
      string idioma = Lenguage.idioma == null ? "es" : Lenguage.idioma;
      int posIdioma = idioma == "es" ? 0 : idioma == "en" ? 1 : idioma == "de" ? 2 : 0;
      if (!text.text.Equals(clickParada[posIdioma]))
      {
         SceneManager.LoadScene(3);
      }
   }

   public void switchSceneIdiomas()
   {
      OpenInfo.cambioIdioma = true;
      SceneManager.LoadScene(0);
   }
}
