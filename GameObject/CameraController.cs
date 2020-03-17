using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera camera;
    Vector3 cameraPos;
    bool firstStart = true;
    

    void Awake()
    {
        camera = GetComponent<Camera>();
        if (firstStart)
        {
            //Debug.Log("작동됨1");
            cameraPos = new Vector3(8.5f, 5.4f, -10f);
            camera.transform.position = cameraPos;
            firstStart = false;
        }
    }

    public void MoveCamera(int cameraPosition)
    {
        switch (cameraPosition) {
            case 0:
                cameraPos = new Vector3(8.5f, 5.4f, -10f);
                camera.transform.position = cameraPos;
                break;
            case 1:
                cameraPos = new Vector3(21.8f, 5.4f, -10f);
                camera.transform.position = cameraPos;
                break;
            case 2:
                cameraPos = new Vector3(27f, -3.65f, -10f);
                camera.transform.position = cameraPos;
                break;
            case 3:
                cameraPos = new Vector3(27f, -12f, -10f);
                camera.transform.position = cameraPos;
                break;
            case 4:
                cameraPos = new Vector3(13.5f, -12f, -10f);
                camera.transform.position = cameraPos;
                break;
            case 5:
                cameraPos = new Vector3(40.4f, -12f, -10f);
                camera.transform.position = cameraPos;
                break;

        }
        
    }
} 

