using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMesh : MonoBehaviour
{
    public int currentInt= 0;
    public List<GameObject> debugMeshGameobject = new List<GameObject>();
    public GameObject controlPlaneG;

    public RawImageWarpDraggableHandle[] RawImageWarpDraggableHandles;
    // Start is called before the first frame update
    void Start()
    {
        RawImageWarpDraggableHandles = FindObjectsOfType<RawImageWarpDraggableHandle>();
        turnOffHandlerImage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("running");

            if (!controlPlaneG.active)
            {
                turnOnHandlerImage();
            }
            else
            {
                turnOffHandlerImage();
            }

            controlPlaneG.SetActive(!controlPlaneG.active);

           
        }
    }

    private void turnOnHandlerImage()
    {
        foreach (var item in RawImageWarpDraggableHandles)
        {
            item.GetComponent<Image>().enabled = true;
        }
    }

    private void turnOffHandlerImage()
    {
        foreach (var item in RawImageWarpDraggableHandles)
        {
            item.GetComponent<Image>().enabled = false;
        }
    }

    public void SetActive()
    {
        int temp = intLoop();
        currentInt = temp;
        foreach (var item in debugMeshGameobject)
        {
            if (debugMeshGameobject.IndexOf(item) == temp)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }


    int intLoop()
    {
        int TEMP = currentInt+1;
        Debug.Log(TEMP);

 
        if(TEMP > debugMeshGameobject.Count - 1)
        {
            return 0;
        }

        return TEMP;
    }
}
