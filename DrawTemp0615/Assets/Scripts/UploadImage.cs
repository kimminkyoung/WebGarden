using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UploadImage : MonoBehaviour
{
    public string uploadURL = "http://bebeamplants.cafe24.com/myform";
    public Texture2D image;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UploadPNG());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UploadPNG()
    {
        yield return new WaitForEndOfFrame();

        byte[] bytes = image.EncodeToPNG();

        WWWForm form = new WWWForm();

        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("fileUpload", bytes, "myImage.png", "image/png");

        using(var w = UnityWebRequest.Post(uploadURL, form))
        {
            yield return w.SendWebRequest();
            if(w.isNetworkError || w.isHttpError)
            {
                print(w.error);
            }
            else
            {
                print("good");
            }
        }
    }
}
