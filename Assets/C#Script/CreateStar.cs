using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateStar : MonoBehaviour
{
    public GameObject diamondConstellation;
    public GameObject starConstellation;

    //���������Ă��邩�J�E���g����ϐ�
    //int clearCount;

    //�_�C�������̐���
    public void DiamondStarsCreate()
    {
        Instantiate(diamondConstellation);
        CheckConstellation.clearCount = 4;
    }

    public void StarConstellation()
    {
        Instantiate(starConstellation);
        CheckConstellation.clearCount = 5;
    }

    //�I�u�W�F�N�g�̃��Z�b�g
    public void ResetStar()
    {
        GameObject[] solidLineToDestroy = GameObject.FindGameObjectsWithTag("solidLine");
        GameObject starToDestroy = GameObject.FindGameObjectWithTag("constellation");

        // �����̃I�u�W�F�N�g��j��
        foreach (GameObject obj in solidLineToDestroy)
        {
            Destroy(obj);
        }

        // ���̃I�u�W�F�N�g��j��
        Destroy(starToDestroy);

        //���C�������̏d���`�F�b�N���X�g�����Z�b�g
        PlayerController.existingLines.Clear();

    }

}
