using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebcamMananger : MonoBehaviour
{
    WebCamDevice[] webdevices;
    public WebCamDevice PubWebcam;
    public WebCamTexture PubTexture;

    // Start is called before the first frame update
    /*void Start()
    {
        
        webdevices = WebCamTexture.devices;
        for (int i = 0; i < webdevices.Length; i++)
        {
            //사용가능한 웹캠 확인
            print("available webcam : " + webdevices[i].name + ", num is " + i + 
                ", is front facing? : " + webdevices[i].isFrontFacing);

            if (webdevices[i].isFrontFacing)
            {
                PubWebcam = webdevices[i];
                SetWebCamTexture(i);
                return;
            }
        }
    }*/

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
            print("webcam is usable now");
        else
            print("cannot use webcam");
    }

    void SetWebCamTexture(int WebcamNum)
    {
        WebCamTexture webcamTexture = new WebCamTexture(webdevices[WebcamNum].name);
        if (webcamTexture != null)
        {
            RawImage showImage = GetComponent<RawImage>();
            showImage.texture = webcamTexture;
            webcamTexture.Play();
            PubTexture = webcamTexture;
            //다른 카메라 앱을 실행하는 도중에 연결하면 안됨
        }
        else
        {
            print("no available cam is here");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            webdevices = WebCamTexture.devices;
            for (int i = 0; i < webdevices.Length; i++)
            {
                //사용가능한 웹캠 확인
                print("available webcam : " + webdevices[i].name + ", num is " + i +
                    ", is front facing? : " + webdevices[i].isFrontFacing);

                if (webdevices[i].isFrontFacing)
                {
                    PubWebcam = webdevices[i];
                    SetWebCamTexture(i);
                    return;
                }
            }
        }
    }

}
