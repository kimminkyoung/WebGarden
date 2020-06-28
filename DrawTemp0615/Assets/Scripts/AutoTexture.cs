using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTexture : MonoBehaviour
{
    public Texture2D autoImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        print("click");
        TextureIn();
    }

    public void TextureIn()
    {
        GetComponent<MeshRenderer>().material.mainTexture = autoImage;
    }
}
