using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarpContorlPlane : MonoBehaviour
{
   public enum ControlMode { cornors, Beziers}

    public ControlMode controlMode;

    public List<DisplayControl> displayControls = new List<DisplayControl>();

    public RawImageWarpDraggableHandle currentOnActiveRawImageWarpHandle;

    public int currentDisplayIndex;

    public Text Displaytext;

    public bool isTurnOnEdit;
    
    // Start is called before the first frame update
    void Start()
    {
        currentDisplayIndex = 0;
        Displaytext.text = "1";
        controlMode = ControlMode.cornors;
        currentOnActiveRawImageWarpHandle = displayControls[currentDisplayIndex].Corners[0];
    }

    public void SetControlMode(int _controlMode)
    {

        if (_controlMode == 0)
        {
            controlMode = ControlMode.cornors;
            currentOnActiveRawImageWarpHandle.setDeActive();
            currentOnActiveRawImageWarpHandle = displayControls[currentDisplayIndex].Corners[0];
        }
        else if (_controlMode == 1)
        {
            controlMode = ControlMode.Beziers;
            currentOnActiveRawImageWarpHandle.setDeActive();
            currentOnActiveRawImageWarpHandle = displayControls[currentDisplayIndex].BeziersVerterx[0];
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentDisplayIndex = 0;
            Displaytext.text = "1";
            controlMode = ControlMode.cornors;
            currentOnActiveRawImageWarpHandle.setDeActive();
            currentOnActiveRawImageWarpHandle = displayControls[currentDisplayIndex].Corners[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentDisplayIndex = 1;
            Displaytext.text = "2";
            controlMode = ControlMode.cornors;
            currentOnActiveRawImageWarpHandle.setDeActive();
            currentOnActiveRawImageWarpHandle = displayControls[currentDisplayIndex].Corners[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentDisplayIndex = 2;
            Displaytext.text = "3";
            controlMode = ControlMode.cornors;
            currentOnActiveRawImageWarpHandle.setDeActive();
            currentOnActiveRawImageWarpHandle = displayControls[currentDisplayIndex].Corners[0];
        }



        switch (controlMode)
        {
            case ControlMode.cornors:
                VertexControlFun();
                break;
            case ControlMode.Beziers:
                VertexControlFun();
                break;
            default:
                break;
        }
  
      
    }




    void VertexControlFun()
    {

        if (!isTurnOnEdit)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentOnActiveRawImageWarpHandle.setdefaultColor();
                currentOnActiveRawImageWarpHandle = currentOnActiveRawImageWarpHandle.next;
                currentOnActiveRawImageWarpHandle.setSelect();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentOnActiveRawImageWarpHandle.setdefaultColor();
                currentOnActiveRawImageWarpHandle = currentOnActiveRawImageWarpHandle.pervious;
                currentOnActiveRawImageWarpHandle.setSelect();

            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isTurnOnEdit = !isTurnOnEdit;
            if (isTurnOnEdit)
            {
                currentOnActiveRawImageWarpHandle.setActive();

            }
            else
            {
                currentOnActiveRawImageWarpHandle.setDeActive();
            }

        }
    }


    void BeziersControlFun()
    {

    }
}




[System.Serializable]
public class DisplayControl{
    public string name;
    public List<RawImageWarpDraggableHandle> Corners = new List<RawImageWarpDraggableHandle>();
    public List<RawImageWarpDraggableHandle> BeziersVerterx = new List<RawImageWarpDraggableHandle>();


}
