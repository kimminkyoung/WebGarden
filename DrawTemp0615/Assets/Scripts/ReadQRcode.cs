using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ZXing;

public class ReadQRcode : MonoBehaviour
{
    public WebcamMananger ins_Webcam;
    public Texture2D QRcodeImage;
    bool Find = false;
    // Start is called before the first frame update
    void Start()
    {
        /*
        IBarcodeReader reader = new BarcodeReader();
        var codeBitmap = QRcodeImage.GetPixels32();
        var result = reader.Decode(codeBitmap, QRcodeImage.width, QRcodeImage.height);

        
        if(result != null)
        {
            print(result.BarcodeFormat.ToString());
            print(result.Text);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(ins_Webcam.PubTexture != null && Find == false)
        {
            IBarcodeReader reader = new BarcodeReader();
            
            var codeBitmap = ins_Webcam.PubTexture.GetPixels32(); //QRcodeImage.GetPixels32();
            //이 텍스쳐가 리더블로 런타임중에 바뀌어야하는데 그럴라믄 readpixels로 해야함
            //var codeBitmap = QRcodeImage.GetPixels32();
            //var result = reader.Decode(codeBitmap, QRcodeImage.width, QRcodeImage.height);
            var result = reader.Decode(codeBitmap, QRcodeImage.width, QRcodeImage.height);

            if (result != null)
            {
                print(result.BarcodeFormat.ToString());
                print(result.Text);
                Find = true;
            }
            else
            {
                print("can't Find QRcode");
            }
        }


    }
}
