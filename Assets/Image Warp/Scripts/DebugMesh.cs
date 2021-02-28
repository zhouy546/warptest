using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMesh : MonoBehaviour
{
    public int currentInt= 0;
    public List<GameObject> debugMeshGameobject = new List<GameObject>();
    public GameObject controlPlaneG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("running");
            controlPlaneG.SetActive(!controlPlaneG.active);
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
