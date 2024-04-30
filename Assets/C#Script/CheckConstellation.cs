using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckConstellation : MonoBehaviour
{

    //星座の位置変数
    Vector3 trianglePos1 = new Vector3(0f, 3f, 0f);
    Vector3 trianglePos2 = new Vector3(-3f, 0f, 0f);
    Vector3 trianglePos3 = new Vector3(3f, 0f, 0f);

    public int consClearNo = 1;
    //星座が作れているかカウントする変数
    int clearCount;

    public bool nextFlag;

    //星座が作れているか判定する関数、プレイヤーScから呼び出す
    public void CheckTriangleCons(GameObject obj)
    {
        LineRenderer lineRenderer = obj.GetComponent<LineRenderer>();
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 position = lineRenderer.GetPosition(i);
            if (position == trianglePos1)
            {
                clearCount++;
            }
            else if (position == trianglePos2)
            {
                clearCount++;
            }
            else if (position == trianglePos3)
            {
                clearCount++;
            }
            else
            {
                clearCount--;
            }
        }

        if (clearCount == 6)
        {
            consClearNo = 2;
            nextFlag = true;
        }
    }
}
