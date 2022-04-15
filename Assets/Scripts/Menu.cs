using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public static Menu instance;
   public static int backScene;
   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
      }
      else
      {
         if (instance != this)
         {
            //Destroy(gameObject);
         }
      }
   }
   
   public void openMenu()
   {
      backScene =  SceneManager.GetActiveScene().buildIndex;
      Debug.Log(backScene); 
      SceneManager.LoadScene(9);
   }
   
   public void closeMenu()
   {
      SceneManager.LoadScene(backScene);
   }
}
