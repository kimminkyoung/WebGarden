using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class FileSaveDesktop : MonoBehaviour
{
    public Texture2D SourceImage;
    string DesktopPath;
    // Start is called before the first frame update
    void Start()
    {
        /*
        DesktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        //File.Create(DesktopPath + "/tempFile.png");
        byte[] bytes = SourceImage.EncodeToPNG();
        File.WriteAllBytes(DesktopPath + "/SourceImage.png", bytes);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        print("클릭");
        DesktopSave();
    }
    void DesktopSave()
    {
        DesktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        //File.Create(DesktopPath + "/tempFile.png");
        byte[] bytes = SourceImage.EncodeToPNG();
        File.WriteAllBytes(DesktopPath + "/SourceImage.png", bytes);
    }
}
