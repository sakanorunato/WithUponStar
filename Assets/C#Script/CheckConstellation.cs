using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckConstellation : MonoBehaviour
{

    public int consClearNo = 1;
    //���������Ă��邩�J�E���g����ϐ��ACreateStar�ɓn��
    public static int clearCount;
    private int checkCount;
    public bool nextFlag;

    //���������Ă��邩���肷��֐��A�v���C���[Sc����Ăяo��
    public void CheckDiamondCons(List<GameObject> obj)
    {
        checkCount = 0;
        for (int i = 0; i < obj.Count; i++)
        {
            checkCount++;
        }
        Debug.Log(checkCount);

        if (checkCount == clearCount)
        {
            consClearNo++;
            nextFlag = true;
        }
    }
}
