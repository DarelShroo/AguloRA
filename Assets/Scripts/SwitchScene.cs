using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{
   public void switchScene(int scene)
   {
      SceneManager.LoadScene(scene);
   }
   public void switchSceneactivarAr(Text text)
   {
      if (text.text != "Clica sobre una parada ...")
      {
         SceneManager.LoadScene(3);
      }
   }
}
