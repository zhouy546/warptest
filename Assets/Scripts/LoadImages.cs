using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImages : MonoBehaviour
{
    public string LeftImageName;
    public string RightImageName;
    public string TopImageUrlName;
    public string BottomImageName;

    public Image LeftImage;
    public Image RightImage;
    public Image TopImage;
    public Image BottomImage;

    // Start is called before the first frame update
    void Start()
    {
        LoadImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadImage()
    {
        LeftImage.sprite = GetSpritefromImage(GetImagePath(LeftImageName));
        RightImage.sprite = GetSpritefromImage(GetImagePath(RightImageName));
        TopImage.sprite = GetSpritefromImage(GetImagePath(TopImageUrlName));
        BottomImage.sprite = GetSpritefromImage(GetImagePath(BottomImageName));
    }

    private string GetImagePath(string imgName)
    {

        //Create an array of file paths from which to choose
        string folderPath = Application.streamingAssetsPath ;  //Get path of folder
        //string[] filePaths = Directory.GetFiles(folderPath, "*.png"); // Get all files of type .png in this folder
        string path =folderPath+"/"  + imgName; //han de ser formato png

        return path;
    }

    private Sprite GetSpritefromImage(string imgPath)
    {

        //Converts desired path into byte array
        byte[] pngBytes = System.IO.File.ReadAllBytes(imgPath);

        //Creates texture and loads byte array data to create image
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);

        //Creates a new Sprite based on the Texture2D
        Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        return fromTex;

    }
}
