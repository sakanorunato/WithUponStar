using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateStar : MonoBehaviour
{
    public GameObject star;
    public GameObject solidLine;
    //�O�p�`�̐����̈ʒu�ϐ�
    Vector3[] trianglePositions = new Vector3[]
   {
        new Vector3(0f, 3f, 0f),
        new Vector3(-3f, 0f, 0f),
        new Vector3(3f, 0f, 0f)
   };

    //�l�p�`�̐����̈ʒu�ϐ�
    Vector3[] rectanglePositions = new Vector3[]
    {
        new Vector3(-2f, 1f, 0f),
        new Vector3(-2f, -2f, 0f),
        new Vector3(2f, 1f, 0f),
        new Vector3(2f, -2f, 0f)
    };

    //���������Ă��邩�J�E���g����ϐ�
    //int clearCount;

    //�O�p�`�̐���
    public void TriangleStarCleate()
    {
        foreach (Vector3 position in trianglePositions)
        {
            Instantiate(star, position, Quaternion.identity);
        }
    }

    //�l�p�`�̐���
    public void RectangleStarCleate()
    {
        foreach (Vector3 position in rectanglePositions)
        {
            Instantiate(star, position, Quaternion.identity);
        }
    }

    //�I�u�W�F�N�g�̃��Z�b�g
    public void ResetStar()
    {
        GameObject[] solidLineToDestroy = GameObject.FindGameObjectsWithTag("solidLine");
        GameObject[] starToDestroy = GameObject.FindGameObjectsWithTag("star");

        // �����̃I�u�W�F�N�g��j��
        foreach (GameObject obj in solidLineToDestroy)
        {
            Destroy(obj);
        }

        // ���̃I�u�W�F�N�g��j��
        foreach (GameObject obj in starToDestroy)
        {
            Destroy(obj);
        }

    }

}
