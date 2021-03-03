using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using LitJson;
//using Custom.Log;
using System.Text;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;
using Fenderrio.ImageWarp;

public class LitJsonExample : MonoBehaviour
{
    public List<RawImageWarp> rawImageWarps = new List<RawImageWarp>();

    void Start()
    {

    }

    public void SaveJson()
    {
        JsonData jd = new JsonData();

        JsonData Arr = new JsonData();


        foreach (RawImageWarp item in rawImageWarps)
        {
            CornerNode cornerNode = new CornerNode(item.cornerOffsetTL, item.cornerOffsetTR, item.cornerOffsetBR, item.cornerOffsetBL);
            BezierNode bezierNode = new BezierNode(true, item.topBezierHandleA, item.topBezierHandleB, item.leftBezierHandleA, item.leftBezierHandleB, item.rightBezierHandleA, item.rightBezierHandleB, item.bottomBezierHandleA, item.bottomBezierHandleB);

            Display temp = new Display(rawImageWarps.IndexOf(item) + 1, cornerNode, bezierNode);

            Arr.Add(ConvertClassToJsonData(temp));
        }
        jd["Display"] = Arr;//标题

        JsonData data = new JsonData();

        data["info"] = jd;//大分类

        string json = data.ToJson();

        List<string> tempJsonStringArray = new List<string>();

        tempJsonStringArray.Add(json);

        UpdateJson(tempJsonStringArray.ToArray());

    }


    JsonData ConvertClassToJsonData(object obj)
    {
        JsonData temp = new JsonData();

        temp.Add(JsonMapper.ToObject(JsonMapper.ToJson(obj)));
        return temp;
    } 


    public void UpdateJson(string[] Jsonarray) {
        string temp = "";
        for (int i = 0; i < Jsonarray.Length; i++)
        {
            temp += Jsonarray[i];
        }

        string ss2 = Regex.Unescape(temp);
        CreatJsonFile(ss2);
    }


    [Serializable]
    public class Display
    {
        public int index;
        public BezierNode bezierNodes;
        public CornerNode cornerNode;

        public Display()
        {
        }

        public Display(int _index, CornerNode _cornerNode, BezierNode _bezierNodes)
        {
            index = _index;
            cornerNode = _cornerNode;
            bezierNodes = _bezierNodes;
         }
    }


    [Serializable]
    public class CornerNode
    {
        public string[] TopLeft;

        public string[] TopRight;

        public string[] BottomRight;

        public string[] BottomLeft;

        public CornerNode()
        {

        }

        public CornerNode(Vector3 _TopLeft,Vector3 _TopRight,Vector3 _BottomRight,Vector3 _BottomLeft)
        {
            string[] TLtemp = new string[3];
            TLtemp[0] = _TopLeft.x.ToString();
            TLtemp[1] = _TopLeft.y.ToString();
            TLtemp[2] = _TopLeft.z.ToString();
            TopLeft = TLtemp;

            string[] TRtemp = new string[3];
            TRtemp[0] = _TopRight.x.ToString();
            TRtemp[1] = _TopRight.y.ToString();
            TRtemp[2] = _TopRight.z.ToString();
            TopRight = TRtemp;

            string[] BRtemp = new string[3];
            BRtemp[0] = _BottomRight.x.ToString();
            BRtemp[1] = _BottomRight.y.ToString();
            BRtemp[2] = _BottomRight.z.ToString();
            BottomRight = BRtemp;

            string[] BLtemp = new string[3];
            BLtemp[0] = _BottomLeft.x.ToString();
            BLtemp[1] = _BottomLeft.y.ToString();
            BLtemp[2] = _BottomLeft.z.ToString();
            BottomLeft = BLtemp;

    }

        public Vector3 GetVector3FromString(string[] st)
        {
            return new Vector3(float.Parse(st[0]), float.Parse(st[1]), float.Parse(st[2]));
        }
    }


    [Serializable]
    public class BezierNode
    {
        public bool Enable;

        public string[] TopBezierHandleA;

        public string[] TopBezierHandleB;

        public string[] LeftBezierHandleA;

        public string[] LeftBezierHandleB;

        public string[] RightBezierHandleA;

        public string[] RightBezierHandleB;

        public string[] BottomBezierHandleA;

        public string[] BottomBezierHandleB;

        public BezierNode()   //有时不写默认构造 会报错
        {
        }

        public BezierNode(bool _enable, Vector3 _TopBezierHandleA, Vector3 _TopBezierHandleB, Vector3 _LeftBezierHandleA, Vector3 _LeftBezierHandleB, Vector3 _RightBezierHandleA, Vector3 _RightBezierHandleB, Vector3 _BottomBezierHandleA, Vector3 _BottomBezierHandleB)
        {
            Enable = _enable;

            string[] tempTOPA = new string[3];
            tempTOPA[0] = _TopBezierHandleA.x.ToString();
            tempTOPA[1] = _TopBezierHandleA.y.ToString();
            tempTOPA[2] = _TopBezierHandleA.z.ToString();
            TopBezierHandleA = tempTOPA;

            string[] tempTOPB = new string[3];
            tempTOPB[0] = _TopBezierHandleB.x.ToString();
            tempTOPB[1] = _TopBezierHandleB.y.ToString();
            tempTOPB[2] = _TopBezierHandleB.z.ToString();
            TopBezierHandleB = tempTOPB;



            string[] tempLEFTA = new string[3];
            tempLEFTA[0] = _LeftBezierHandleA.x.ToString();
            tempLEFTA[1] = _LeftBezierHandleA.y.ToString();
            tempLEFTA[2] = _LeftBezierHandleA.z.ToString();
            LeftBezierHandleA = tempLEFTA;


            string[] tempLEFTB = new string[3];
            tempLEFTB[0] = _LeftBezierHandleB.x.ToString();
            tempLEFTB[1] = _LeftBezierHandleB.y.ToString();
            tempLEFTB[2] = _LeftBezierHandleB.z.ToString();
            LeftBezierHandleB = tempLEFTB;

            string[] tempRightA = new string[3];
            tempRightA[0] = _RightBezierHandleA.x.ToString();
            tempRightA[1] = _RightBezierHandleA.y.ToString();
            tempRightA[2] = _RightBezierHandleA.z.ToString();
            RightBezierHandleA = tempRightA;

            string[] tempRightB = new string[3];
            tempRightB[0] = _RightBezierHandleB.x.ToString();
            tempRightB[1] = _RightBezierHandleB.y.ToString();
            tempRightB[2] = _RightBezierHandleB.z.ToString();
            RightBezierHandleB = tempRightB;

            string[] tempBottomA = new string[3];
            tempBottomA[0] = _BottomBezierHandleA.x.ToString();
            tempBottomA[1] = _BottomBezierHandleA.y.ToString();
            tempBottomA[2] = _BottomBezierHandleA.z.ToString();
            BottomBezierHandleA = tempBottomA;

            string[] tempBottomB = new string[3];
            tempBottomB[0] = _BottomBezierHandleB.x.ToString();
            tempBottomB[1] = _BottomBezierHandleB.y.ToString();
            tempBottomB[2] = _BottomBezierHandleB.z.ToString();
            BottomBezierHandleB = tempBottomB;

        }

        public Vector3 GetVector3FromString(string [] st)
        {
            return new Vector3(float.Parse(st[0]),float.Parse(st[1]), float.Parse(st[2]));
        }
    }


    void CreatJsonFile(string jsonStr)
    {
        string spath = Application.streamingAssetsPath + "/information.json";
        StringBuilder sb = new StringBuilder();
        StreamWriter sw;
        FileInfo info = new FileInfo(spath);
        if (!info.Exists)
        {
            sw = info.CreateText();
            print("文件不存在，创建数据");
        }
        else
        {
            info.Delete();
            print("文件已经存在，删除数据");
            sw = info.CreateText();
        }

        sw.Write(jsonStr);
        sw.Close();

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }

}
