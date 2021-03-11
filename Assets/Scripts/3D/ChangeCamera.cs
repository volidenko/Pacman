using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    private Camera TheCamera;
    private Camera Cam;
    public bool firstLook;
    // Start is called before the first frame update
    void Start()
    {
        TheCamera=GetComponent<Camera>();
        TheCamera=Camera.main;
        firstLook=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
        TheCamera.enabled=!TheCamera.enabled;
        Cam.enabled=!Cam.enabled;
        firstLook=!firstLook;
        }
    }
}
