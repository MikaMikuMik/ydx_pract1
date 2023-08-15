using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    float CameraMoveFwdSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(CameraMoveFwdSpeed, 0, 0);
    }

    public void SetCameraSpeed(float inCameraMoveFwdSpeed)
    {
        CameraMoveFwdSpeed = inCameraMoveFwdSpeed;
    }

    public void SetInitPosition()
    {
        transform.position = new Vector3(0, 0, -10); 
    }
}
