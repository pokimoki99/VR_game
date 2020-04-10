using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Scene_manager
{
 
    public static void Load()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {

            SceneManager.LoadScene("Character_Selection");
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Character_Selection"))
        {

            SceneManager.LoadScene("Overground");
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Overground"))
        {

            SceneManager.LoadScene("Open_arena");
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Open_arena"))
        {

            SceneManager.LoadScene("Underground_arena");
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Underground_arena"))
        {

            SceneManager.LoadScene("Bossfight");
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Bossfight"))
        {

            SceneManager.LoadScene("SampleScene");
        }


    }
}
