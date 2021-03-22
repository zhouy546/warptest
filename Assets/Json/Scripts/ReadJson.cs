using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using System.IO;

using LitJson;

using UnityEngine.UI;
using System.Text.RegularExpressions;
using Fenderrio.ImageWarp;

public class ReadJson : MonoBehaviour {


    public static ReadJson instance;

    public LitJsonExample jsonExample;

  //  public  Ntext ntext;

    private JsonData itemDate;

    private string jsonString;


    public List<LitJsonExample.Display> displays = new List<LitJsonExample.Display>();

    public void Start()
    {
        StartCoroutine(initialization());
    }

    public IEnumerator initialization() {
        if (instance == null)
        {

            instance = this;

        }

     yield return   StartCoroutine(readJson());
    }

    IEnumerator readJson() {
        string spath = Application.streamingAssetsPath + "/information.json";

        Debug.Log(spath);

        WWW www = new WWW(spath);

        yield return www;

        jsonString = System.Text.Encoding.UTF8.GetString(www.bytes);

        JsonMapper.ToObject(www.text);

       itemDate = JsonMapper.ToObject(jsonString.ToString());

        for (int i = 0; i < itemDate["info"]["Display"].Count; i++)
        {
            int DisplayIndex = int.Parse(itemDate["info"]["Display"][i][0]["index"].ToString());
            //Debug.Log(itemDate["info"]["Display"][i][0]["bezierNodes"]["Enable"].ToString());

         bool Enable =    itemDate["info"]["Display"][i][0]["bezierNodes"]["Enable"].ToString() == "True" ? true: false;

        float xval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["TopBezierHandleA"][0].ToString());
        float yval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["TopBezierHandleA"][1].ToString());
        float zval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["TopBezierHandleA"][2].ToString());
        Vector3 TopBezierHandleA = new Vector3(xval,yval,zval);

             xval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["TopBezierHandleB"][0].ToString());
             yval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["TopBezierHandleB"][1].ToString());
             zval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["TopBezierHandleB"][2].ToString());
            Vector3 TopBezierHandleB = new Vector3(xval, yval, zval);

             xval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["LeftBezierHandleA"][0].ToString());
             yval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["LeftBezierHandleA"][1].ToString());
             zval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["LeftBezierHandleA"][2].ToString());
            Vector3 LeftBezierHandleA = new Vector3(xval, yval, zval);

             xval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["LeftBezierHandleB"][0].ToString());
             yval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["LeftBezierHandleB"][1].ToString());
             zval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["LeftBezierHandleB"][2].ToString());
            Vector3 LeftBezierHandleB = new Vector3(xval, yval, zval);

            xval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["RightBezierHandleA"][0].ToString());
            yval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["RightBezierHandleA"][1].ToString());
            zval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["RightBezierHandleA"][2].ToString());
            Vector3 RightBezierHandleA = new Vector3(xval, yval, zval);

            xval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["RightBezierHandleB"][0].ToString());
            yval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["RightBezierHandleB"][1].ToString());
            zval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["RightBezierHandleB"][2].ToString());
            Vector3 RightBezierHandleB = new Vector3(xval, yval, zval);

            xval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["BottomBezierHandleA"][0].ToString());
            yval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["BottomBezierHandleA"][1].ToString());
            zval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["BottomBezierHandleA"][2].ToString());
            Vector3 BottomBezierHandleA = new Vector3(xval, yval, zval);

            xval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["BottomBezierHandleB"][0].ToString());
            yval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["BottomBezierHandleB"][1].ToString());
            zval = float.Parse(itemDate["info"]["Display"][i][0]["bezierNodes"]["BottomBezierHandleB"][2].ToString());
            Vector3 BottomBezierHandleB = new Vector3(xval, yval, zval);

            xval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["TopLeft"][0].ToString());
            yval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["TopLeft"][1].ToString());
            zval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["TopLeft"][2].ToString());
            Vector3 TopLeft = new Vector3(xval, yval, zval);

            xval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["TopRight"][0].ToString());
            yval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["TopRight"][1].ToString());
            zval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["TopRight"][2].ToString());
            Vector3 TopRight = new Vector3(xval, yval, zval);

            xval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["BottomRight"][0].ToString());
            yval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["BottomRight"][1].ToString());
            zval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["BottomRight"][2].ToString());
            Vector3 BottomRight = new Vector3(xval, yval, zval);

            xval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["BottomLeft"][0].ToString());
            yval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["BottomLeft"][1].ToString());
            zval = float.Parse(itemDate["info"]["Display"][i][0]["cornerNode"]["BottomLeft"][2].ToString());
            Vector3 BottomLeft = new Vector3(xval, yval, zval);

            LitJsonExample.BezierNode bezierNode = new LitJsonExample.BezierNode(Enable, TopBezierHandleA, TopBezierHandleB, LeftBezierHandleA, LeftBezierHandleB, RightBezierHandleA, RightBezierHandleB, BottomBezierHandleA, BottomBezierHandleB);
            LitJsonExample.CornerNode cornerNode = new LitJsonExample.CornerNode(TopLeft,TopRight,BottomRight,BottomLeft);


            LitJsonExample.Display display = new LitJsonExample.Display(DisplayIndex, cornerNode, bezierNode);

            displays.Add(display);
        }

        SetJsonDataToObject();
    }



    public void SetJsonDataToObject()
    {

        foreach (RawImageWarp item in jsonExample.rawImageWarps)
        {
            int index = jsonExample.rawImageWarps.IndexOf(item);

            //Debug.Log(displays[index].bezierNodes.GetVector3FromString(displays[index].bezierNodes.TopBezierHandleA));

            item.topBezierHandleA = displays[index].bezierNodes.GetVector3FromString(displays[index].bezierNodes.TopBezierHandleA);
            item.topBezierHandleB = displays[index].bezierNodes.GetVector3FromString(displays[index].bezierNodes.TopBezierHandleB);

            item.leftBezierHandleA = (displays[index].bezierNodes.GetVector3FromString(displays[index].bezierNodes.LeftBezierHandleA));
            item.leftBezierHandleB = (displays[index].bezierNodes.GetVector3FromString(displays[index].bezierNodes.LeftBezierHandleB));

            item.rightBezierHandleA = (displays[index].bezierNodes.GetVector3FromString(displays[index].bezierNodes.RightBezierHandleA));
            item.rightBezierHandleB = (displays[index].bezierNodes.GetVector3FromString(displays[index].bezierNodes.RightBezierHandleB));

            item.bottomBezierHandleA = (displays[index].bezierNodes.GetVector3FromString(displays[index].bezierNodes.BottomBezierHandleA));
            item.bottomBezierHandleB = (displays[index].bezierNodes.GetVector3FromString(displays[index].bezierNodes.BottomBezierHandleB));

            item.cornerOffsetTL=(displays[index].cornerNode.GetVector3FromString(displays[index].cornerNode.TopLeft));
            item.cornerOffsetTR = (displays[index].cornerNode.GetVector3FromString(displays[index].cornerNode.TopRight));
            item.cornerOffsetBL= (displays[index].cornerNode.GetVector3FromString(displays[index].cornerNode.BottomLeft));
            item.cornerOffsetBR= (displays[index].cornerNode.GetVector3FromString(displays[index].cornerNode.BottomRight));


        }
    }
}


