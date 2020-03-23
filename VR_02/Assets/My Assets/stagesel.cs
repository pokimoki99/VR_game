using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stagesel : MonoBehaviour
{
    public void Changing_scene()
    {
        Debug.Log("change scene being called");
        Scene_manager.Load(Scene_manager.Scene.SampleScene);
    }
}