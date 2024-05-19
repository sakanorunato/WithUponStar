using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckConstellation : MonoBehaviour
{

    public int consClearNo = 1;
    //星座が作れているかカウントする変数、CreateStarに渡す
    public static int clearCount;
    private int checkCount;
    public bool nextFlag;

    //星座が作れているか判定する関数、プレイヤーScから呼び出す
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
