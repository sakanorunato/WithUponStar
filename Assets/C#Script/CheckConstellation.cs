using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckConstellation : MonoBehaviour
{

    //�����̈ʒu�ϐ�
    Vector3 trianglePos1 = new Vector3(0f, 3f, 0f);
    Vector3 trianglePos2 = new Vector3(-3f, 0f, 0f);
    Vector3 trianglePos3 = new Vector3(3f, 0f, 0f);

    //GameManager manager = new GameManager();

    public bool triangleClear = false;
    //���������Ă��邩�J�E���g����ϐ�
    int clearCount;

    //���������Ă��邩���肷��֐��A�v���C���[Sc����Ăяo��
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
            triangleClear = true;
            manager.gameProceesFlag = true;
        }
    }
}
