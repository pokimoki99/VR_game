using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UIElements;

public class enemy_canvas_camera : MonoBehaviour
{
    public Canvas _canvas;
    Camera _camera;
    // Start is called before the first frame update
    private void Awake()
    {

        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _canvas.worldCamera = _camera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
