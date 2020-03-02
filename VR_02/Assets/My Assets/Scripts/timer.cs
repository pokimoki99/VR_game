using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    public static int timerstart = 210; 
    public Text textu;
    public Text text1;
    public Text text2;

    // Start is called before the first frame update
    void Start()
    {
        cdt();
    }
    void cdt()
    {
        if (timerstart > -1) 
        {
          textu.text= ""+ timerstart;
          text1.text= ""+ timerstart;
          text2.text= ""+ timerstart;
            timerstart--;
            Invoke("cdt", 1.0f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        //transform.LookAt(Camera.main.transform.rotation * Vector3.up);
        //transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward);
    }
}
