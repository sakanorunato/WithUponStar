using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateStar : MonoBehaviour
{
    public GameObject diamondConstellation;
    public GameObject starConstellation;

    //星座が作れているかカウントする変数
    //int clearCount;

    //ダイヤ星座の生成
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

    //オブジェクトのリセット
    public void ResetStar()
    {
        GameObject[] solidLineToDestroy = GameObject.FindGameObjectsWithTag("solidLine");
        GameObject starToDestroy = GameObject.FindGameObjectWithTag("constellation");

        // 実線のオブジェクトを破棄
        foreach (GameObject obj in solidLineToDestroy)
        {
            Destroy(obj);
        }

        // 星のオブジェクトを破棄
        Destroy(starToDestroy);

        //ライン生成の重複チェックリストをリセット
        PlayerController.existingLines.Clear();

    }

}
