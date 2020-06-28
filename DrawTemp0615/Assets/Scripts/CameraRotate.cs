using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Vector3 CamRot;
    public Vector3 MouseRot;
    

    // Start is called before the first frame update
    void Start()
    {
        CameraRotation();
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
        MouseRot = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
    }

    void CameraRotation()
    {
        
        CamRot = GetComponent<Transform>().rotation.eulerAngles;
        CamRot = new Vector3(CamRot.x - Input.GetAxis("Mouse Y"), 
                             CamRot.y + Input.GetAxis("Mouse X"), 
                             CamRot.z);
        
        Quaternion quatCamRot = Quaternion.Euler(CamRot);
        quatCamRot.z = 0;
        GetComponent<Transform>().rotation = quatCamRot;

    }
}
