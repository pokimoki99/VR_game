using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Scene_manager 
{ 
    // Start is called before the first frame update
    public enum Scene { 
    MainMenu,Character_Selection, SampleScene, Open_arena,Underground_arena,Bossfight
    }

    // Update is called once per frame
    public static void Load(Scene scen)
    {
       
        SceneManager.LoadScene(scen.ToString());
    }
}
