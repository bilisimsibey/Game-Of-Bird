using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    public static float setX;


    private void Update()
    {
        if (scriptBird.instance!=null)
        {
            if (scriptBird.instance.isAlive)
            {
                MovetheCamera();
            }
        }
    }
    void MovetheCamera()
    {
        Vector3 temp = transform.position;
        temp.x = scriptBird.instance.GetPositionX();
        transform.position = temp;
    }
}
